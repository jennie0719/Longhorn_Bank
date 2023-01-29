using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Team3_FinalProject.DAL;
using Team3_FinalProject.Models;

namespace Team3_FinalProject.Seeding
{
    public static class SeedAccounts
    { 
        public static void SeedAllAccounts(AppDbContext db)
        {
            if (db.Accounts.Count() == 22)
            {
                throw new NotSupportedException("The database already contains all 23 Account!");
            }

            Int32 intAccountsAdded = 0;
            String strAccount = "Begin"; //helps to keep track of error on books
            List<Account> Accounts = new List<Account>();

            try
            {
                Account a1 = new Account()
                {
                    AccountName = "William's Savings",
                    AccountType = AccountType.Savings,
                    AccountNo = 2290000002,
                    Balance = 40035.50m,



                };
                a1.AppUser = db.Users.FirstOrDefault(a => a.Email == "willsheff@email.com");

                Accounts.Add(a1);

                Account a2 = new Account()
                {
                    AccountName = " Gregory's Checking",
                    AccountType = AccountType.Checking,
                    AccountNo = 2290000003,
                    Balance = 39779.49m,



                };
                a2.AppUser = db.Users.FirstOrDefault(a => a.Email == "smartinmartin.Martin@aool.com");

                Accounts.Add(a2);

                Account a3 = new Account()
                {
                    AccountName = " Allen's Checking",
                    AccountType = AccountType.Checking,
                    AccountNo = 2290000004,
                    Balance = 47277.33m,



                };
                a3.AppUser = db.Users.FirstOrDefault(a => a.Email == "avelasco@yaho.com");

                Accounts.Add(a3);

                Account a4 = new Account()
                {
                    AccountName = " Reagan's Checking",
                    AccountType = AccountType.Checking,
                    AccountNo = 2290000005,
                    Balance = 70812.15m,



                };
                a4.AppUser = db.Users.FirstOrDefault(a => a.Email == "rwood@voyager.net");

                Accounts.Add(a4);

                Account a5 = new Account()
                {
                    AccountName = " Kelly's Savings",
                    AccountType = AccountType.Savings,
                    AccountNo = 2290000006,
                    Balance = 21801.97m,



                };
                a5.AppUser = db.Users.FirstOrDefault(a => a.Email == "nelson.Kelly@aool.com");

                Accounts.Add(a5);

                Account a6 = new Account()
                {
                    AccountName = " Eryn's Checking",
                    AccountType = AccountType.Checking,
                    AccountNo = 2290000007,
                    Balance = 70480.99m,



                };
                a6.AppUser = db.Users.FirstOrDefault(a => a.Email == "erynrice@aool.com");

                Accounts.Add(a6);

                Account a7 = new Account()
                {
                    AccountName = "Jake's Savings",
                    AccountType = AccountType.Savings,
                    AccountNo = 2290000008,
                    Balance = 7916.40m,



                };
                a7.AppUser = db.Users.FirstOrDefault(a => a.Email == "westj@pioneer.net");

                Accounts.Add(a7);

                Account a8 = new Account()
                {
                    AccountName = " Jeffrey's Savings",
                    AccountType = AccountType.Savings,
                    AccountNo = 2290000010,
                    Balance = 69576.83m,



                };
                a8.AppUser = db.Users.FirstOrDefault(a => a.Email == "jeff@ggmail.com");

                Accounts.Add(a8);

                Account a9 = new Account()
                {
                    AccountName = "Eryn's Checking 2",
                    AccountType = AccountType.Checking,
                    AccountNo = 2290000012,
                    Balance = 30279.33m,



                };
                a9.AppUser = db.Users.FirstOrDefault(a => a.Email == "erynrice@aool.com");

                Accounts.Add(a9);

                Account a10 = new Account()
                {
                    AccountName = " Jennifer's IRA",
                    AccountType = AccountType.IRA,
                    AccountNo = 2290000013,
                    Balance = 53177.21m,



                };
                a10.AppUser = db.Users.FirstOrDefault(a => a.Email == "mackcloud@pimpdaddy.com");


                Accounts.Add(a10);


                Account a11 = new Account()
                {
                    AccountName = "Sarah's Savings",
                    AccountType = AccountType.Savings,
                    AccountNo = 2290000014,
                    Balance = 11958.08m,



                };
                a11.AppUser = db.Users.FirstOrDefault(a => a.Email == "ss34@ggmail.com");

                Accounts.Add(a11);


                Account a12 = new Account()
                {
                    AccountName = " Jeremy's Savings",
                    AccountType = AccountType.Savings,
                    AccountNo = 2290000015,
                    Balance = 72990.47m,



                };
                a12.AppUser = db.Users.FirstOrDefault(a => a.Email == " tanner@ggmail.com");

                Accounts.Add(a12);

                Account a13 = new Account()
                {
                    AccountName = " Elizabeth's Savings",
                    AccountType = AccountType.Savings,
                    AccountNo = 2290000016,
                    Balance = 7417.20m,



                };
                a13.AppUser = db.Users.FirstOrDefault(a => a.Email == " liz@ggmail.com");

                Accounts.Add(a13);

                Account a14 = new Account()
                {
                    AccountName = " Allen's IRA",
                    AccountType = AccountType.IRA,
                    AccountNo = 2290000017,
                    Balance = 75866.69m,



                };
                a14.AppUser = db.Users.FirstOrDefault(a => a.Email == " ra@aoo.com");

                Accounts.Add(a14);

                Account a15 = new Account()
                {
                    AccountName = "Clarence's Savings",
                    AccountType = AccountType.Savings,
                    AccountNo = 2290000019,
                    Balance = 1642.82m,



                };
                a15.AppUser = db.Users.FirstOrDefault(a => a.Email == "mclarence@aool.com");

                Accounts.Add(a15);

                Account a16 = new Account()
                {
                    AccountName = "Sarah's Checking",
                    AccountType = AccountType.Checking,
                    AccountNo = 2290000020,
                    Balance = 84421.45m,



                };
                a16.AppUser = db.Users.FirstOrDefault(a => a.Email == "ss34@ggmail.com");

                Accounts.Add(a16);

                Account a17 = new Account()
                {
                    AccountName = " CBaker's Checking",
                    AccountType = AccountType.Checking,
                    AccountNo = 2290000021,
                    Balance = 4523.00m,



                };
                a17.AppUser = db.Users.FirstOrDefault(a => a.Email == "cbaker@freezing.co.uk");

                Accounts.Add(a17);

                Account a18 = new Account()
                {
                    AccountName = " CBaker's Savings",
                    AccountType = AccountType.Savings,
                    AccountNo = 2290000022,
                    Balance = 1000.00m,



                };
                a18.AppUser = db.Users.FirstOrDefault(a => a.Email == "cbaker@freezing.co.uk");

                Accounts.Add(a18);

                Account a19 = new Account()
                {
                    AccountName = " CBaker's IRA",
                    AccountType = AccountType.IRA,
                    AccountNo = 2290000023,
                    Balance = 1000.00m,



                };
                a19.AppUser = db.Users.FirstOrDefault(a => a.Email == "cbaker@freezing.co.uk");

                Accounts.Add(a19);


                Account a20 = new Account()
                {
                    AccountName = " C-dawg's Checking",
                    AccountType = AccountType.Checking,
                    AccountNo = 2290000025,
                    Balance = 4.04m,



                };
                a20.AppUser = db.Users.FirstOrDefault(a => a.Email == "chaley@thug.com");

                Accounts.Add(a20);

                Account a21 = new Account()
                {
                    AccountName = " C-dawg's Savings",
                    AccountType = AccountType.Savings,
                    AccountNo = 2290000026,
                    Balance = 350.00m,



                };
                a21.AppUser = db.Users.FirstOrDefault(a => a.Email == "chaley@thug.com");

                Accounts.Add(a21);

                Account a22 = new Account()
                {
                    AccountName = " Margaret's IRA",
                    AccountType = AccountType.IRA,
                    AccountNo = 2290000027,
                    Balance = 3500.00m,


                };
                a22.AppUser = db.Users.FirstOrDefault(a => a.Email == "mgar@aool.com");

                Accounts.Add(a22);

                Account a23 = new Account()
                {
                    AccountName = "Shan's Checking",
                    AccountType = AccountType.Checking,
                    AccountNo = 2290000028,
                    Balance = 2657.81m,


                };
                a23.AppUser = db.Users.FirstOrDefault(a => a.Email == "Dixon@aool.com");

                Accounts.Add(a23);








                try
                {
                    foreach (Account accountToAdd in Accounts)
                    {
                        int intAccountID = accountToAdd.AccountID;
                        Account dbAccount = db.Accounts.FirstOrDefault(b => b.AccountID == accountToAdd.AccountID);
                        if (dbAccount == null) //this title doesn't exist
                        {
                            db.Accounts.Add(accountToAdd);
                            db.SaveChanges();
                            intAccountsAdded += 1;
                        }
                        else //property exists - update values
                        {

                            dbAccount.AccountName = accountToAdd.AccountName;
                            dbAccount.AccountType = accountToAdd.AccountType;
                            db.Update(dbAccount);
                            db.SaveChanges();
                            intAccountsAdded += 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    String msg = "  Repositories added:" + intAccountsAdded + "; Error on " + strAccount;
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


