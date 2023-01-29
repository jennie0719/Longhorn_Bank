using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Team3_FinalProject.DAL;
using Team3_FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Runtime.Intrinsics.Arm;
using Team3_FinalProject.Utilities;
using Team3_FinalProject.SendMail;


namespace Team3_FinalProject.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly AppDbContext _context;

        public AccountsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public IActionResult Index()
        {
            //Set up a list of accounts to display
            List<Account> accounts;
            if (User.IsInRole("Customer")) //user is a customer, so only display their records
            {
                accounts = _context.Accounts
                                .Include(a => a.Transactions)
                                .ThenInclude(a => a.Disputes)
                                .Include(a => a.AppUser)
                                .Where(a => a.AppUser.UserName == User.Identity.Name)
                                .ToList();
                if (accounts[0].AppUser.Disabled)
                {
                    //add an error to the model to show invalid attempt
                    ModelState.AddModelError("", "Disabled customer can no longer view accounts.");
                    //send user back to login page to try again
                    return RedirectToAction("Index","Account");
                }
            }
            else 
            {
                accounts = _context.Accounts
                                .Include(a => a.Transactions)
                                .ThenInclude(a => a.Disputes)
                                .Include(a => a.AppUser)
                                .ToList();
            }

            //
            return View(accounts);
        }


        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return View("Error", new string[] { "Please specify an account to view!" });
            }

            

            var account = await _context.Accounts
                .Include(acc => acc.Transactions)
                .ThenInclude(acc => acc.Disputes)
                .Include(acc => acc.AppUser)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            
            if (account == null)
            {
                return NotFound();
            }
            if (account.Transactions == null)
            {
                return RedirectToAction("Transact", "Transactions", new { accountID = id });
            }
            if (User.IsInRole("Customer") && account.AppUser.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not authorized to view this account!" });
            }
            if (User.IsInRole("Customer") && !account.Active)
            {
                return View("Error", new String[] { "This account is inactivate right now!" });
            }

            return View(account);
        }

        // GET: Accounts/Apply
        [Authorize(Roles = "Customer")]
        public IActionResult Apply()
        {
            return View();
        }

        // POST: Accounts/Apply
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Apply([Bind("AccountID,AccountType,AccountName")] Account account)
        {
            account.AccountNo = Utilities.GenerateNextAccountNumber.GetNextAccountNumber(_context);
            account.AppUser = _context.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            ViewBag.ErrorMessage = "";

            List<Account> accounts = _context.Accounts
                                .Include(a => a.Transactions)
                                .ThenInclude(a => a.Disputes)
                                .Include(a => a.AppUser)
                                .Where(a => a.AppUser.UserName == User.Identity.Name)
                                .ToList();

            if (account.AccountType == AccountType.IRA && accounts.Where(a => a.AccountType == AccountType.IRA).Count() >= 1)
            {
                ViewBag.ErrorMessage = "Each customer may only have one IRA.";
                return View(account);
            }

            if (account.AccountName == null)
            {
                account.AccountName = "Longhorn "+account.AccountType.ToString() +" "+ (accounts.Where(a => a.AccountType == account.AccountType).Count()+1).ToString();
            }
            if (account.AccountType == AccountType.IRA)
            {
                account.Contribution = 0;
            }
            if (ModelState.IsValid)
            {
                account.Active = false;
                _context.Add(account);
                await _context.SaveChangesAsync();

                //Send Email
                String emailSubject = "Welcome to LonghornBank03!";
                String emailBody = @"<div>Hi " + account.AppUser.FirstName + ",</div><br/>";
                emailBody = emailBody + @"<div>Thank you for choosing Longhorn Bank. </div><br/>";
                emailBody = emailBody + @"<div> Your account:</div>" + account.AccountName;
                emailBody = emailBody + @"<div> has been created! Whee!</div><br/>";

                EmailMessaging.SendEmail(account.AppUser.Email, emailSubject, emailBody);
                return RedirectToAction("Transact","Transactions", new { accountID = account.AccountID });
            }

            return View(account);
        }

        // GET: Accounts/Edit/5
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return View("Error", new string[] { "Please specify an account to edit!" });
            }

            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }
            if (account.Transactions == null)
            {
                return RedirectToAction("Transact", "Transactions", new { accountID = id });
            }
            if (!account.Active)
            {
                return View("Error", new String[] { "This account is inactivate right now!" });
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Account account)
        {
            if (id != account.AccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Account dbAccount = _context.Accounts.Find(account.AccountID);
                    dbAccount.AccountName = account.AccountName;
                    _context.Update(dbAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), new { id = id});
            }
            return View(account);
        }

        // GET: Accounts/Inactivate/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Inactivate(int? id)
        {
            if (id == null || _context.Accounts == null)
            {
                return View("Error", new string[] { "Please specify an account to activate/inactivate!" });
            }

            var account = await _context.Accounts
                .Include(a=>a.AppUser)
                .Include(a=>a.Transactions)
                .FirstOrDefaultAsync(m => m.AccountID == id);
            if (account.Active)
            {
                ViewBag.CurrentStatus = "Active";
                ViewBag.StatusChanged = "Inactivate";
            }
            else
            {
                ViewBag.CurrentStatus = "Inactive";
                ViewBag.StatusChanged = "Activate";
            }
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Inactivate/5
        [HttpPost, ActionName("Inactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InactivateConfirmed(int id)
        {
            if (_context.Accounts == null)
            {
                return Problem("Entity set 'AppDbContext.Accounts'  is null.");
            }
            var account = await _context.Accounts.FindAsync(id);
            if (account != null)
            {
                Account dbAccount = _context.Accounts.Find(account.AccountID);
                dbAccount.Active = !account.Active;
                _context.Update(dbAccount);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
          return _context.Accounts.Any(e => e.AccountID == id);
        }
    }
}
