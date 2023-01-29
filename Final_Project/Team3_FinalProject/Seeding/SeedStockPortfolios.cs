using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Team3_FinalProject.DAL;
using Team3_FinalProject.Models;

namespace Team3_FinalProject.Seeding
{
    public static class SeedStockPortfolios
    {
        public static void SeedAllStockPortfolios(AppDbContext db)
        {

            Int32 intStockPortfoliosAdded = 0;
            String strStockPortfolio = "Begin"; //helps to keep track of error on books
            List<StockPortfolio> StockPortfolios = new List<StockPortfolio>();

            try
            {
                StockPortfolio sp1 = new StockPortfolio()
                {
                    AccountName = "Shan's Stock",
                    CashValuePortion = 0.00m,
                    StockPortion = 0.00m,
                    Bonus = 0.00m,
                    TotalValue = 0.00m,
                    AccountNo = 2290000001
                };
                sp1.AppUser = db.Users.FirstOrDefault(sp => sp.Email == "Dixon@aool.com");
                StockPortfolios.Add(sp1);

                StockPortfolio sp2 = new StockPortfolio()
                {
                    AccountName = " Michelle's Stock",
                    CashValuePortion = 8888.88m,
                    StockPortion = 0.00m,
                    Bonus = 0.00m,
                    TotalValue = 8888.88m,
                    AccountNo = 2290000009
                };
                sp2.AppUser = db.Users.FirstOrDefault(sp => sp.Email == "mb@aool.com");
                StockPortfolios.Add(sp2);

                StockPortfolio sp3 = new StockPortfolio()
                {
                    AccountName = "Kelly's Stock",
                    CashValuePortion = 420.00m,
                    StockPortion = 0.00m,
                    Bonus = 0.00m,
                    TotalValue = 420.00m,
                    AccountNo = 2290000011
                };
                sp3.AppUser = db.Users.FirstOrDefault(sp => sp.Email == "nelson.Kelly@aool.com");
                StockPortfolios.Add(sp3);

                StockPortfolio sp4 = new StockPortfolio()
                {
                    AccountName = " John's Stock",
                    CashValuePortion = 0.00m,
                    StockPortion = 0.00m,
                    Bonus = 0.00m,
                    TotalValue = 0.00m,
                    AccountNo = 2290000018
                };
                sp4.AppUser = db.Users.FirstOrDefault(sp => sp.Email == "johnsmith187@aool.com");
                StockPortfolios.Add(sp4);

                StockPortfolio sp5 = new StockPortfolio()
                {
                    AccountName = "CBaker's Stock",
                    CashValuePortion = 6900.00m,
                    StockPortion = 0.00m,
                    Bonus = 0.00m,
                    TotalValue = 6900.00m,
                    AccountNo = 2290000024
                };
                sp5.AppUser = db.Users.FirstOrDefault(sp => sp.Email == "cbaker@freezing.co.uk");
                StockPortfolios.Add(sp5);



                try
                {
                    foreach (StockPortfolio stockportfolioToAdd in StockPortfolios)
                    {
                        uint StockPortfolioAccountNo = stockportfolioToAdd.AccountNo;
                        StockPortfolio dbStockPortfolio = db.StockPortfolios.FirstOrDefault(sp => sp.AccountNo == stockportfolioToAdd.AccountNo);
                        if (dbStockPortfolio == null) //this title doesn't exist
                        {
                            db.StockPortfolios.Add(stockportfolioToAdd);
                            db.SaveChanges();
                            intStockPortfoliosAdded += 1;
                        }
                        else //property exists - update values
                        {

                            dbStockPortfolio.AccountName = stockportfolioToAdd.AccountName;
                            dbStockPortfolio.CashValuePortion = stockportfolioToAdd.CashValuePortion;
                            db.Update(dbStockPortfolio);
                            db.SaveChanges();
                            intStockPortfoliosAdded += 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    String msg = "  Repositories added:" + intStockPortfoliosAdded + "; Error on " + strStockPortfolio;
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


