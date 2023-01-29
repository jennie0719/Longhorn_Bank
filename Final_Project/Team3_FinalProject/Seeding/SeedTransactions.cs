using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Team3_FinalProject.DAL;
using Team3_FinalProject.Models;

namespace Team3_FinalProject.Seeding
{
    public class SeedTransactions
    {
        public static void SeedAllTransactions(AppDbContext db)
        {

            Int32 intTransactionsAdded = 0;
            String strTransactions = "Begin"; //helps to keep track of error on Transactions
            List<Transaction> Transactions = new List<Transaction>();

            try
            {
                Transaction t1 = new Transaction()
                {
                    TransactionComment = "",
                    TransactionNumber = 1,
                    TransactionDate = new DateTime(2022, 1, 15),
                    TransactionType = TransactionType.Deposit,
                    Approved = true,
                    TransactionAmount = 4000.00m,
                };
                t1.Account = db.Accounts.FirstOrDefault(t => t.AccountNo == 2290000021);


                Transactions.Add(t1);

                Transaction t2 = new Transaction()
                {
                    TransactionComment = "This transaction went so well! I will be using this bank again for sure!!",
                    TransactionNumber = 2,
                    TransactionDate = new DateTime(2022, 3, 5),
                    TransactionType = TransactionType.Deposit,
                    Approved = true,
                    TransactionAmount = 2200.00m,
                };
                t2.Account = db.Accounts.FirstOrDefault(t => t.AccountNo == 2290000022);


                Transactions.Add(t2);

                Transaction t3 = new Transaction()
                {
                    TransactionComment = "",
                    TransactionNumber = 3,
                    TransactionDate = new DateTime(2022, 3, 9),
                    TransactionType = TransactionType.Deposit,
                    Approved = true,
                    TransactionAmount = 6000.00m,
                };
                t3.Account = db.Accounts.FirstOrDefault(t => t.AccountNo == 2290000022);


                Transactions.Add(t3);

                Transaction t4 = new Transaction()
                {
                    TransactionComment = "Jacob Foster has a GPA of 1.92. LOL",
                    TransactionNumber = 4,
                    TransactionDate = new DateTime(2022, 4, 14),
                    TransactionType = TransactionType.Transfer,
                    Approved = true,
                    TransactionAmount = +1200.00m,
                };
                t4.Account = db.Accounts.FirstOrDefault(t => t.AccountNo == 2290000021);


                Transactions.Add(t4);

                Transaction t5 = new Transaction()
                {
                    TransactionComment = "Jacob Foster has a GPA of 1.92. LOL",
                    TransactionNumber = 4,
                    TransactionDate = new DateTime(2022, 4, 14),
                    TransactionType = TransactionType.Transfer,
                    Approved = true,
                    TransactionAmount = -1200.00m,
                };
                t5.Account = db.Accounts.FirstOrDefault(t => t.AccountNo == 2290000022);


                Transactions.Add(t5);

                Transaction t6 = new Transaction()
                {
                    TransactionComment = "Longhorn Bank is my favorite bank! I couldn't dream of putting my money anywhere else.",
                    TransactionNumber = 5,
                    TransactionDate = new DateTime(2022, 4, 21),
                    TransactionType = TransactionType.Withdrawal,
                    Approved = true,
                    TransactionAmount = 352.00m,
                };
                t6.Account = db.Accounts.FirstOrDefault(t => t.AccountNo == 2290000022);


                Transactions.Add(t6);

                Transaction t7 = new Transaction()
                {
                    TransactionComment = " ",
                    TransactionNumber = 6,
                    TransactionDate = new DateTime(2022, 3, 8),
                    TransactionType = TransactionType.Deposit,
                    Approved = true,
                    TransactionAmount = 1500.00m,
                };
                t7.Account = db.Accounts.FirstOrDefault(t => t.AccountNo == 2290000023);


                Transactions.Add(t7);

                Transaction t8 = new Transaction()
                {
                    TransactionComment = " ",
                    TransactionNumber = 7,
                    TransactionDate = new DateTime(2022, 4, 20),
                    TransactionType = TransactionType.Transfer,
                    Approved = true,
                    TransactionAmount = +3000.00m,
                };
                t8.Account = db.Accounts.FirstOrDefault(t => t.AccountNo == 2290000021);


                Transactions.Add(t8);

                Transaction t9 = new Transaction()
                {
                    TransactionComment = " ",
                    TransactionNumber = 7,
                    TransactionDate = new DateTime(2022, 4, 20),
                    TransactionType = TransactionType.Transfer,
                    Approved = true,
                    TransactionAmount = -3000.00m,
                };
                t9.Account = db.Accounts.FirstOrDefault(t => t.AccountNo == 2290000024);


                Transactions.Add(t9);


                Transaction t10 = new Transaction()
                {
                    TransactionComment = "K project snack expenses",
                    TransactionNumber = 8,
                    TransactionDate = new DateTime(2022, 4, 19),
                    TransactionType = TransactionType.Withdrawal,
                    Approved = true,
                    TransactionAmount = 578.12m,
                };
                t10.Account = db.Accounts.FirstOrDefault(t => t.AccountNo == 2290000021);


                Transactions.Add(t10);


                Transaction t11 = new Transaction()
                {
                    TransactionComment = " ",
                    TransactionNumber = 9,
                    TransactionDate = new DateTime(2022, 4, 29),
                    TransactionType = TransactionType.Transfer,
                    Approved = true,
                    TransactionAmount = +52.00m,
                };
                t11.Account = db.Accounts.FirstOrDefault(t => t.AccountNo == 2290000025);


                Transactions.Add(t11);

                Transaction t12 = new Transaction()
                {
                    TransactionComment = " ",
                    TransactionNumber = 9,
                    TransactionDate = new DateTime(2022, 4, 29),
                    TransactionType = TransactionType.Transfer,
                    Approved = true,
                    TransactionAmount = -52.00m,
                };
                t12.Account = db.Accounts.FirstOrDefault(t => t.AccountNo == 2290000026);


                Transactions.Add(t12);


                Transaction t13 = new Transaction()
                {
                    TransactionComment = "This is totally not fraudulent 0_o",
                    TransactionNumber = 10,
                    TransactionDate = new DateTime(2022, 3, 7),
                    TransactionType = TransactionType.Withdrawal,
                    Approved = true,
                    TransactionAmount = 4000.00m,
                };
                t13.Account = db.Accounts.FirstOrDefault(t => t.AccountNo == 2290000020);


                Transactions.Add(t13);
                Transaction t14 = new Transaction()
                {
                    TransactionComment = " I got this money from my new business at the Blue Cat Lodge",
                    TransactionNumber = 11,
                    TransactionDate = new DateTime(2022, 5, 1),
                    TransactionType = TransactionType.Deposit,
                    Approved = false,
                    TransactionAmount = 6000.00m,
                };
                t14.Account = db.Accounts.FirstOrDefault(t => t.AccountNo == 2290000016);


                Transactions.Add(t14);


                try
                {
                    foreach (Transaction transactionToAdd in Transactions)
                    {
                       int intTransactionId = transactionToAdd.TransactionID;
                        Transaction dbTransaction = db.Transactions.FirstOrDefault(tr=> tr.TransactionID == tr.TransactionID);
                        if (dbTransaction == null) //this title doesn't exist
                        {
                            db.Transactions.Add(transactionToAdd);
                            db.SaveChanges();
                            intTransactionsAdded += 1;
                        }
                        else //property exists - update values
                        {

                            dbTransaction.TransactionComment = transactionToAdd.TransactionComment;
                            dbTransaction.TransactionNumber = transactionToAdd.TransactionNumber;
                            dbTransaction.TransactionDate = transactionToAdd.TransactionDate;
                            dbTransaction.TransactionType = transactionToAdd.TransactionType;
                            dbTransaction.Approved = transactionToAdd.Approved;
                            dbTransaction.TransactionAmount = transactionToAdd.TransactionAmount;

                            db.Update(dbTransaction);
                            db.SaveChanges();
                            intTransactionsAdded += 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    String msg = "  Repositories added:" + intTransactionsAdded + "; Error on " + strTransactions;
                    throw new InvalidOperationException(ex.Message + msg);
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }


        }


        }
    }       
 
