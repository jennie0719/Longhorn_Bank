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
using Team3_FinalProject.Utilities;
using Team3_FinalProject.SendMail;

namespace Team3_FinalProject.Controllers
{
    [Authorize]
    public class DisputesController : Controller
    {
        private readonly AppDbContext _context;

        public DisputesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Disputes
        [Authorize(Roles = "Admin")]
        public IActionResult Index(Status? SearchStatus)
        {
            var query = from d in _context.Disputes select d;
            if (SearchStatus == Status.Submitted)
            {
                query = query.Where(d => d.DisputeStatus == Status.Submitted);
            }
            List<Dispute> ShowDisputes = query
                                                .Include(d => d.Transaction)
                                                .ThenInclude(d => d.Account)
                                                .ThenInclude(d => d.AppUser)
                                                .ToList();

            return View(ShowDisputes.OrderByDescending(d => d.DisputeID));
        }

        // GET: Disputes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Disputes == null)
            {
                return View("Error", new String[] { "Please specify a dispute to view!" });
            }

            var dispute = await _context.Disputes
                .Include(txn => txn.Transaction)
                .ThenInclude(txn => txn.Account)
                .ThenInclude(txn => txn.AppUser)
                .FirstOrDefaultAsync(d => d.DisputeID == id);
            if (dispute == null)
            {
                return NotFound();
            }

            if (User.IsInRole("Customer") && dispute.Transaction.Account.AppUser.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not authorized to view this order!" });
            }

            return View(dispute);
        }

        // GET: Disputes/Create
        [Authorize(Roles = "Customer")]
        public IActionResult Create(int? transactionID)
        {
            if (transactionID == null)
            {
                return View("Error", new String[] { "Please specify a transaction to dispute!" });
            }
            Dispute dis = new Dispute();
            Transaction dbTransaction = _context.Transactions.Find(transactionID);
            List<Dispute> disputes = _context.Disputes.Where(d => d.Transaction == dbTransaction).ToList();

            if (disputes.Count() != 0)
            {
                if (disputes.Last().DisputeStatus == Status.Submitted)
                {
                    return View("Error", new String[] { "This transaction has been disputed and has not yet been resolved." });
                }
                if (disputes.Last().DisputeStatus == Status.Accepted)
                {
                    return View("Error", new String[] { "This transaction has a dispute accepted already." });
                }
            }
            

            dis.Transaction = dbTransaction;
            return View(dis);
        }

        // POST: Disputes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dispute dispute)
        {            
            Transaction dbTransaction = _context.Transactions.Find(dispute.Transaction.TransactionID);
            dispute.Transaction = dbTransaction;
            dispute.DisputeStatus = Status.Submitted;

            if (dbTransaction.TransactionAmount<0 && dispute.CorrectAmount > 0)
            {
                dispute.CorrectAmount = -dispute.CorrectAmount;
            }
            if (dbTransaction.TransactionAmount > 0 && dispute.CorrectAmount < 0)
            {
                dispute.CorrectAmount = -dispute.CorrectAmount;
            }
            if (dispute.DeleteTransaction)
            {
                dispute.CorrectAmount = 0;
            }

            _context.Add(dispute);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Transactions", new { id = dispute.Transaction.TransactionID });
        }

        // GET: Disputes/Resolve/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Resolve(int? id)
        {
            if (id == null || _context.Disputes == null)
            {
                return View("Error", new String[] { "Please specify a dispute to resolve!" });
            }

            var dispute = await _context.Disputes
                .Include(o => o.Transaction)
                .FirstOrDefaultAsync(m => m.DisputeID == id);
            ViewBag.OriginalAmount = dispute.Transaction.TransactionAmount;

            if (dispute == null)
            {
                return NotFound();
            }
            if (dispute.DisputeStatus != Status.Submitted)
            {
                return View("Error", new string[] { "This dispute is resolved and cannot be changed!" });
            }

            return View(dispute);
        }

        // POST: Disputes/Resolve/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Resolve(int id, Dispute dispute)
        {
            if (id != dispute.DisputeID)
            {
                return NotFound();
            }

            Dispute dbDispute = _context.Disputes.Include(t => t.Transaction).ThenInclude(t=>t.Account).ThenInclude(t=>t.AppUser).Where(d => d.DisputeID == id).ToList()[0];

            if (ModelState.IsValid)
            {
                try
                {
                    dbDispute.AdminComment = dispute.AdminComment;
                    dbDispute.DisputeStatus = dispute.DisputeStatus;
                    _context.Update(dbDispute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisputeExists(dispute.DisputeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                if (dispute.DisputeStatus == Status.Accepted || dispute.DisputeStatus == Status.Adjusted)
                {
                    Account dbAccount = _context.Accounts.Find(dbDispute.Transaction.Account.AccountID);
                    Transaction dbTransaction = _context.Transactions.Find(dbDispute.Transaction.TransactionID);
                    dbAccount.Balance -= dbTransaction.TransactionAmount;
                    dbAccount.Balance += dispute.CorrectAmount;
                    dbTransaction.TransactionAmount = dispute.CorrectAmount;

                    _context.Update(dbAccount);
                    _context.Update(dbTransaction);
                    await _context.SaveChangesAsync();
                }
                AppUser newUser = dbDispute.Transaction.Account.AppUser;

                //Send Email
                String emailSubject = "Welcome to LonghornBank03!";
                String emailBody = @"<div>Hi " + newUser.FirstName + ",</div><br/>";
                emailBody = emailBody + @"<div>Your dispute </div>" + dbDispute.DisputeID;
                emailBody = emailBody + @"<div> has been resolved.</div><br/>";
                emailBody = emailBody + @"<div>Thank you for banking with us!</div><br/>";

                EmailMessaging.SendEmail(newUser.Email, emailSubject, emailBody);

                return RedirectToAction(nameof(Index));
            }
            return View(dispute);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Disputes == null)
            {
                return NotFound();
            }

            var dispute = await _context.Disputes
                .Include(o => o.Transaction)
                .FirstOrDefaultAsync(m => m.DisputeID == id);
            if (dispute == null)
            {
                return NotFound();
            }

            return View(dispute);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Dispute dispute = await _context.Disputes
                                                   .Include(o => o.Transaction)
                                                   .ThenInclude(o=>o.Account)
                                                   .ThenInclude(o=>o.AppUser)
                                                   .FirstOrDefaultAsync(o => o.DisputeID == id);
            dispute.DisputeStatus = Status.Accepted;
            _context.Update(dispute);
            await _context.SaveChangesAsync();

            Transaction transaction = dispute.Transaction;
            Account account = _context.Accounts.Find(transaction.Account.AccountID);
            account.Balance -= transaction.TransactionAmount;

            _context.Update(account);
            _context.Transactions.Remove(transaction);

            await _context.SaveChangesAsync();

            AppUser newUser = dispute.Transaction.Account.AppUser;

            //Send Email
            String emailSubject = "Welcome to LonghornBank03!";
            String emailBody = @"<div>Hi " + newUser.FirstName + ",</div><br/>";
            emailBody = emailBody + @"<div>Your dispute </div>" + dispute.DisputeID;
            emailBody = emailBody + @"<div> has been resolved.</div><br/>";
            emailBody = emailBody + @"<div>Thank you for banking with us!</div><br/>";

            EmailMessaging.SendEmail(newUser.Email, emailSubject, emailBody);

            return RedirectToAction("Index", "Disputes");
        }

        private bool DisputeExists(int id)
        {
          return _context.Disputes.Any(e => e.DisputeID == id);
        }
    }
}
