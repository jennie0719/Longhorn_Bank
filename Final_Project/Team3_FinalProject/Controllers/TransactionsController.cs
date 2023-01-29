using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Team3_FinalProject.DAL;
using Team3_FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Team3_FinalProject.Utilities;
using Team3_FinalProject.SendMail;

namespace Team3_FinalProject.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly AppDbContext _context;

        public TransactionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public IActionResult Index(String SearchString, int? accountID)
        {
            if (User.IsInRole("Customer") && accountID == null)
            {
                return View("Error", new String[] { "Please specify an account to view!" });
            }
            ViewBag.SelectedAccount = accountID;

            var query = from t in _context.Transactions select t;
            if (SearchString != null)
            {
                query = query.Where(r => r.TransactionDescription.Contains(SearchString));
            }

            if (User.IsInRole("Customer"))
            {
                query = query.Where(t => t.Account.AppUser.UserName == User.Identity.Name && t.Account.AccountID == accountID);
            }

            List<Transaction> SelectedTransactions = query
                                                        .Include(t => t.Account)
                                                        .ThenInclude(t => t.AppUser)
                                                        .Include(t => t.Disputes)
                                                        .ToList();

            if (User.IsInRole("Admin") || User.IsInRole("Employee"))
            {
                ViewBag.AllTransactions = _context.Transactions.Count();
            }
            else //user is a customer, so only display their records
            {
                ViewBag.AllTransactions = _context.Transactions
                                .Where(t => t.Account.AppUser.Email == User.Identity.Name && t.Account.AccountID == accountID)
                                .Count();
            }

            //populate the view bag with a count of selected repositories
            ViewBag.SelectedTransactions = SelectedTransactions.Count();

            return View(SelectedTransactions.OrderByDescending(t => t.TransactionDate));
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return View("Error", new string[] { "Please specify a transaction to view!" });
            }

            var transaction = await _context.Transactions
                .Include(txn => txn.Account)
                .ThenInclude(txn => txn.AppUser)
                .Include(txn => txn.Disputes)
                .FirstOrDefaultAsync(m => m.TransactionID == id);

            if (!transaction.Approved)
            {
                ViewBag.CurrentStatus = "Pending";
            }

            if (transaction == null)
            {
                return NotFound();
            }
            if (User.IsInRole("Customer") && transaction.Account.AppUser.Email != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not authorized to view this order!" });
            }

            return View(transaction);
        }

        // GET: Transactions/Edit/5
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            Transaction transaction = await _context.Transactions
                                              .Include(txn => txn.Account)
                                              .ThenInclude(txn => txn.AppUser)
                                              .Include(txn => txn.Disputes)
                                              .FirstOrDefaultAsync(t => t.TransactionID == id);

            if (transaction == null)
            {
                return NotFound();
            }
            if (transaction.Account.AppUser.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not authorized to view this order!" });
            }

            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Transaction transaction)
        {
            if (id != transaction.TransactionID)
            {
                return NotFound();
            }

            Transaction dbTransaction = _context.Transactions.Find(transaction.TransactionID);
            dbTransaction.TransactionDate = transaction.TransactionDate;
            dbTransaction.TransactionComment = transaction.TransactionComment;
            _context.Update(dbTransaction);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new {id =id});
        }

        // GET: Transactions/Transact
        [Authorize(Roles = "Customer")]
        public IActionResult Transact(int? accountID)
        {
            if (accountID == null)
            {
                ViewBag.AllAccounts = GetAllAccountsSelectList();
                ViewBag.TransactTitle = "Transact";
                ViewBag.AmountNotification = "";
            }
            else
            {
                List<Account> accountList = _context.Accounts.Where(a => a.AccountID == accountID).ToList();
                SelectList accountSelectList = new SelectList(accountList, "AccountID", "AccountName");
                Account dbAccount = _context.Accounts.Find(accountID);
                ViewBag.AllAccounts = accountSelectList;
                ViewBag.TransactTitle = "Initial Deposit";
                ViewBag.AmountNotification = "Please make your initial deposit for " + dbAccount.AccountName;
                if (dbAccount.AccountType == AccountType.IRA)
                {
                    ViewBag.AmountNotification = "Please make your initial deposit for " + dbAccount.AccountName +". An IRA account may have no more than $5000 contribution per year.";
                }
            }
            
            return View();
        }

        // POST: Transactions/Transact
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Customer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transact(Transaction transaction, int SelectedAccount)
        {
            ViewBag.TransactTitle = "Transact";
            List<Account> accountList = _context.Accounts.Where(a => a.AccountID == SelectedAccount).ToList();
            SelectList accountSelectList = new SelectList(accountList, "AccountID", "AccountName");

            if (ModelState.IsValid == false)
            {
                if (ViewBag.TransactTitle == "Initial Deposit")
                {
                    ViewBag.AllAccounts = accountSelectList;
                }
                else
                {
                    ViewBag.AllAccounts = GetAllAccountsSelectList();
                }
                return View(transaction);
            }
            transaction.TransactionNumber = Utilities.GenerateNextTransactionNumber.GetNextTransactionNumber(_context);

            Account dbAccount = _context.Accounts.Find(SelectedAccount);
            dbAccount.AppUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);

            List<Transaction> dbTransactions = _context.Transactions.Where(t => t.Account.AccountID == SelectedAccount).ToList();
            dbAccount.Transactions = dbTransactions;

            if (transaction.TransactionType == TransactionType.Withdrawal && transaction.TransactionAmount > dbAccount.Balance)
            {
                ViewBag.AllAccounts = GetAllAccountsSelectList();
                ViewBag.AmountNotification = "You may withdraw an amount of no more than $"+ dbAccount.Balance + " from "+ dbAccount.AccountName;
                transaction.TransactionAmount = dbAccount.Balance;

                AppUser newUser = dbAccount.AppUser;

                //Send Email
                String emailSubject = "Welcome to LonghornBank03!";
                String emailBody = @"<div>Hi " + newUser.FirstName + ",</div><br/>";
                emailBody = emailBody + @"<div>You may not withdraw an amount of no more than $</div>" + dbAccount.Balance;
                emailBody = emailBody + @"<div> from </div>" + dbAccount.AccountName;
                emailBody = emailBody + @"<br/><div>Go get your bag, queen.</div><br/>";

                EmailMessaging.SendEmail(newUser.Email, emailSubject, emailBody);

                return View(transaction);
            }
            if (dbAccount.AccountType == AccountType.IRA)
            {
                if (transaction.TransactionAmount > 5000)
                {
                    transaction.TransactionAmount = 5000;
                }
                
                dbAccount.Contribution += transaction.TransactionAmount;
            }

            transaction.TransactionDate = DateTime.Now;
            transaction.Approved = true;
            if (transaction.TransactionType == TransactionType.Deposit && transaction.TransactionAmount > 5000)
            {
                transaction.Approved = false;
            }
            else
            {
                dbAccount.Balance += transaction.TransactionAmount;
            }
            if (transaction.TransactionType == TransactionType.Withdrawal)
            {
                transaction.TransactionAmount = -transaction.TransactionAmount;
                dbAccount.Balance += transaction.TransactionAmount;
            }
            _context.Add(transaction);
            await _context.SaveChangesAsync();

            dbAccount.Active = true;
            dbAccount.AppUser.Disabled = false;
            transaction.Account = dbAccount;
            _context.SaveChanges();

            return RedirectToAction("Index", "Accounts");
        }

        // GET: Transactions/Transfer
        [Authorize(Roles = "Customer")]
        public IActionResult Transfer()
        {
            ViewBag.AllAccounts = GetAllTransferrableAccountsSelectList();
            return View();
        }

        // POST: Transactions/Transfer
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Customer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transfer(TransferViewModel tvm)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag.AllAccounts = GetAllTransferrableAccountsSelectList();
                return View(tvm);
            }

            Account dbFromAccount = _context.Accounts.Find(tvm.FromAccount);
            dbFromAccount.AppUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            List<Transaction> dbFromTransactions = _context.Transactions.Where(t => t.Account.AccountID == tvm.FromAccount).ToList();
            dbFromAccount.Transactions = dbFromTransactions;

            Account dbToAccount = _context.Accounts.Find(tvm.ToAccount);
            dbToAccount.AppUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            List<Transaction> dbToTransactions = _context.Transactions.Where(t => t.Account.AccountID == tvm.ToAccount).ToList();
            dbToAccount.Transactions = dbToTransactions;

            if (tvm.TransferAmount > dbFromAccount.Balance)
            {
                ViewBag.AllAccounts = GetAllTransferrableAccountsSelectList();
                ViewBag.AmountNotification = "You may transfer an amount of no more than $" + dbFromAccount.Balance + " from " + dbFromAccount.AccountName;
                tvm.TransferAmount = dbFromAccount.Balance;
                return View(tvm);
            }
            if (dbToAccount.AccountType == AccountType.IRA && DateTime.Now > dbToAccount.AppUser.DOB.AddYears(70))
            {
                ViewBag.AllAccounts = GetAllTransferrableAccountsSelectList();
                ViewBag.AmountNotification = "You are no longer able to contribute to your IRA.";
                tvm.TransferAmount = 5000 - dbToAccount.Contribution;
                return View(tvm);
            }
            if (dbFromAccount.AccountType == AccountType.IRA && DateTime.Now < dbFromAccount.AppUser.DOB.AddYears(65))
            {
                ViewBag.AllAccounts = GetAllTransferrableAccountsSelectList();
                if (tvm.TransferAmount > 3000)
                {
                    ViewBag.AmountNotification = "You may only distribute a maximum amount of $3000 per transfer out of IRA.";
                    tvm.TransferAmount = 3000;
                    return View(tvm);
                }
                if (tvm.TransferFromIRA)
                {
                    return View("TransferConfirm", tvm);
                }
                tvm.TransferFromIRA = true;
                ViewBag.AmountNotification = "There will be a $30 service fee for this unqualified distribution, would you like to add the fee or include the fee in $"+tvm.TransferAmount.ToString()+"?";
                return View(tvm);
            }
            if (dbToAccount.AccountType == AccountType.IRA && tvm.TransferAmount + dbToAccount.Contribution > 5000)
            {
                ViewBag.AllAccounts = GetAllTransferrableAccountsSelectList();
                ViewBag.AmountNotification = "You may contribute an amount of no more than $" + (5000 - dbToAccount.Contribution) + " to " + dbToAccount.AccountName;
                tvm.TransferAmount = 5000 - dbToAccount.Contribution;
                return View(tvm);
            }

            ViewBag.FromAccount = dbFromAccount.AccountTransfer;
            return RedirectToAction("TransferConfirm", new {toAccount = tvm.ToAccount, fromAccount = tvm.FromAccount, date = tvm.TransferDate, amount=tvm.TransferAmount, ira = tvm.TransferFromIRA, iraFee = tvm.IRATransferFeeType});
        }

        // GET: OrderDetails/Create
        [Authorize(Roles = "Customer")]
        public IActionResult TransferConfirm(int toAccount, int fromAccount, DateTime date, decimal amount, bool ira, TransferFeeType iraFee)
        {
            TransferViewModel tvm = new TransferViewModel();

            Account ToAccount = _context.Accounts.Find(toAccount);
            Account FromAccount = _context.Accounts.Find(fromAccount);
            ViewBag.FromAccount = FromAccount.AccountTransfer;
            ViewBag.ToAccount = ToAccount.AccountTransfer;

            tvm.ToAccount = toAccount;
            tvm.FromAccount = fromAccount;
            tvm.TransferDate = date;
            tvm.TransferAmount = amount;
            tvm.TransferFromIRA = ira;
            tvm.IRATransferFeeType = iraFee;

            return View(tvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TransferConfirm(TransferViewModel tvm)
        {
            Account ToAccount = _context.Accounts.Find(tvm.ToAccount);
            Account FromAccount = _context.Accounts.Find(tvm.FromAccount);
            var transactionNumber = Utilities.GenerateNextTransactionNumber.GetNextTransactionNumber(_context);

            Transaction transactionTo = new Transaction
            {
                TransactionNumber = transactionNumber,
                Account = ToAccount,
                TransactionAmount = tvm.TransferAmount,
                TransactionDate = tvm.TransferDate,
                TransactionDescription = "Transfer from account" + FromAccount.AccountNo.ToString(),
                TransactionType = TransactionType.Transfer,
                Approved = true
            };
            Transaction transactionFrom = new Transaction
            {
                TransactionNumber = transactionNumber,
                Account = FromAccount,
                TransactionAmount = -tvm.TransferAmount,
                TransactionDate = tvm.TransferDate,
                TransactionDescription = "Transfer to account" + ToAccount.AccountNo.ToString(),
                TransactionType = TransactionType.Transfer,
                Approved = true
            };

            if (ToAccount.AccountType == AccountType.IRA)
            {
                ToAccount.Contribution += tvm.TransferAmount;
            }

            if (tvm.TransferFromIRA)
            {
                Transaction transactionFee = new Transaction
                {
                    TransactionNumber = transactionNumber,
                    Account = FromAccount,
                    TransactionAmount = -30,
                    TransactionDate = tvm.TransferDate,
                    TransactionDescription = "Transaction Fee for transfer from " + FromAccount.AccountName + " to " + ToAccount.AccountName,
                    TransactionType = TransactionType.Fee,
                    Approved = true
                };
                if (tvm.IRATransferFeeType == TransferFeeType.Include)
                {
                    transactionFrom.TransactionAmount += 30;
                    transactionTo.TransactionAmount -= 30;
                }
                _context.Add(transactionFee);
                await _context.SaveChangesAsync();

                FromAccount.Balance -= 30;
                transactionFee.Account = FromAccount;
                _context.SaveChanges();
            }
            
            _context.Add(transactionTo);
            await _context.SaveChangesAsync();
            ToAccount.Balance += transactionTo.TransactionAmount;
            transactionTo.Account = ToAccount;
            _context.SaveChanges();

            _context.Add(transactionFrom);
            await _context.SaveChangesAsync();
            FromAccount.Balance += transactionFrom.TransactionAmount;
            transactionFrom.Account = FromAccount;
            _context.SaveChanges();

            return RedirectToAction("Index", "Accounts");
        }

        private SelectList GetAllAccountsSelectList()
        {
            List<Account> accountList = _context.Accounts.ToList();

            accountList = _context.Accounts
                                .Include(a => a.AppUser)
                                .Include(a=>a.Transactions)
                                .Where(a => a.AppUser.UserName == User.Identity.Name)
                                .Where(a => a.Active)
                                .ToList();

            SelectList accountSelectList = new SelectList(accountList.OrderBy(a => a.AccountID), "AccountID", "AccountTransfer");

            return accountSelectList;
        }

        //TODO: add stock cash-value portion
        private SelectList GetAllTransferrableAccountsSelectList()
        {
            List<Account> accountList = _context.Accounts.ToList();

            accountList = _context.Accounts
                                .Include(a => a.AppUser)
                                .Include(a=>a.Transactions)
                                .Where(a => a.AppUser.UserName == User.Identity.Name)
                                .Where(a => a.Active)
                                .ToList();

            SelectList accountSelectList = new SelectList(accountList.OrderBy(a => a.AccountID), "AccountID", "AccountTransfer");

            return accountSelectList;
        }

        // GET: Accounts/Approve/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Approve(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return View("Error", new string[] { "Please specify a transaction to approve!" });
            }

            var transaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.TransactionID == id);
            
            if (transaction == null)
            {
                return NotFound();
            }
            if (transaction.Approved)
            {
                return View("Error", new String[] { "This transaction has already been approved!" });
            }
            ViewBag.CurrentStatus = "Pending";

            return View(transaction);
        }

        // POST: Accounts/Approve/5
        [HttpPost, ActionName("Approve")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveConfirmed(int id)
        {
            if (_context.Transactions == null)
            {
                return Problem("Entity set 'AppDbContext.Transactions'  is null.");
            }
            Transaction dbTransaction = await _context.Transactions.Include(t=>t.Account).ThenInclude(t=>t.AppUser).FirstOrDefaultAsync(t=>t.TransactionID == id);
            dbTransaction.Approved = true;
            _context.Update(dbTransaction);
            _context.SaveChanges();

            AppUser newUser = dbTransaction.Account.AppUser;

            //Send Email
            String emailSubject = "Welcome to LonghornBank03!";
            String emailBody = @"<div>Hi " + newUser.FirstName + ",</div><br/>";
            emailBody = emailBody + @"<div>Your transaction </div>"+dbTransaction.TransactionID;
            emailBody = emailBody + @"<div> has been approved. </div><br/>";
            emailBody = emailBody + @"<div>Thank you for banking with us!</div><br/>";
            EmailMessaging.SendEmail(newUser.Email, emailSubject, emailBody);

            return RedirectToAction("Index");

        }

        private bool TransactionExists(int id)
        {
          return _context.Transactions.Any(e => e.TransactionID == id);
        }

        // GET: Transactions/DetailedSearch
        public IActionResult DetailedSearch(int? accountID)
        {
            if (accountID != null)
            {
                ViewBag.DetailedSearchAccount = accountID;
            }
            else
            {
                ViewBag.DetailedSearchAccount = null;
            }

            return View();
        }

        public IActionResult DisplaySearchResults(SearchViewModel svc)
        {
            var query = from t in _context.Transactions select t;

            if (svc.SearchDescription != null)
            {
                query = query.Where(t => t.TransactionDescription.Contains(svc.SearchDescription));
            }
            if (svc.SearchTransactionType != null)
            {
                query = query.Where(t => t.TransactionType == svc.SearchTransactionType);
            }
            if (svc.SearchTransactionNumber != null)
            {
                query = query.Where(t => t.TransactionNumber == svc.SearchTransactionNumber);
            }
            if (svc.SearchMinAmount != null)
            {
                query = query.Where(t => t.TransactionAmount >= svc.SearchMinAmount);
            }
            if (svc.SearchMaxAmount != null)
            {
                query = query.Where(t => t.TransactionAmount <= svc.SearchMaxAmount);
            }
            if (svc.SearchMinDate != null)
            {
                query = query.Where(t => t.TransactionDate >= svc.SearchMinDate);
            }
            if (svc.SearchMaxDate != null)
            {
                query = query.Where(t => t.TransactionDate <= svc.SearchMaxDate);
            }
            if (svc.SelectedAccount != null)
            {
                query = query.Where(t => t.Account.AccountID == svc.SelectedAccount);
            }

            List<Transaction> SelectedTransactions = query.ToList();

            //populate the view bag with a count of all repositories
            if (User.IsInRole("Customer"))
            {
                ViewBag.AllTransactions = _context.Transactions
                                .Where(t => t.Account.AppUser.UserName == User.Identity.Name && t.Account.AccountID == svc.SelectedAccount)
                                .Count();
            }
            else
            {
                ViewBag.AllTransactions = _context.Transactions.Count();
            }

            //populate the view bag with a count of selected repositories
            ViewBag.SelectedTransactions = SelectedTransactions.Count();

            if (svc.SearchSortOrder == SortOrder.Ascending)
            {
                return View("Index", SelectedTransactions.OrderBy(t => svc.SearchSortBy));
            }
            return View("Index", SelectedTransactions.OrderByDescending(t => svc.SearchSortBy));
        }
    }
}
