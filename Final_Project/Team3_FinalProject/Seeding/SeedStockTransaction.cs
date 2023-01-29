using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Team3_FinalProject.DAL;
using Team3_FinalProject.Models;

namespace Team3_FinalProject.Seeding
{
    public static class SeedStockTransaction 
    {
        public static void SeedAllStockTransactions(AppDbContext db)
        {
            Int32 intStockTransactionsAdded = 0;
            String strStockTransaction = "Begin";
           
            List<StockTransaction> StockTransactions = new List<StockTransaction>();
            try
            {
                StockTransaction st1 = new StockTransaction()
                {
                    StockTransactionType = StockTransactionType.Purchase,
                    SharePrice = 145.03m,
                    QuantityShares = 10,
                    StockTXNDate = new DateTime(2022, 4, 1)

                };
                st1.StockPortfolio = db.StockPortfolios.FirstOrDefault(sp => sp.AccountNo == 2290000024);
                st1.Stock = db.Stocks.FirstOrDefault(s => s.TickerSymbol == "AAPL");
                StockTransactions.Add(st1);

                StockTransaction st2 = new StockTransaction()
                {
                    StockTransactionType = StockTransactionType.Purchase,
                    SharePrice = 321.36m,
                    QuantityShares = 5,
                    StockTXNDate = new DateTime(2022,4,3)

                };
                st2.StockPortfolio = db.StockPortfolios.FirstOrDefault(sp => sp.AccountNo == 2290000024);
                st2.Stock = db.Stocks.FirstOrDefault(s => s.TickerSymbol == "DIA");
                StockTransactions.Add(st2);


                StockTransaction st3 = new StockTransaction()
                {
                    StockTransactionType = StockTransactionType.Purchase,
                    SharePrice = 18.10m,
                    QuantityShares = 2,
                    StockTXNDate = new DateTime(2022,4,28)

                };
                st3.StockPortfolio = db.StockPortfolios.FirstOrDefault(sp => sp.AccountNo == 2290000024);
                st3.Stock = db.Stocks.FirstOrDefault(s => s.TickerSymbol == "FLCEX");
                StockTransactions.Add(st3);


                try
                {
                    foreach (StockTransaction stocktransactionToAdd in StockTransactions)
                    {
                        int intStockTransaactionID = stocktransactionToAdd.StockTransactionID;
                        StockTransaction dbStockTransaction = db.StockTransactions.FirstOrDefault(st => st.StockTransactionID == st.StockTransactionID);
                        if (dbStockTransaction == null) //this title doesn't exist
                        {
                            db.StockTransactions.Add(stocktransactionToAdd);
                            db.SaveChanges();
                            intStockTransactionsAdded += 1;
                        }
                        else //property exists - update values
                        {

                            dbStockTransaction.StockTransactionType = stocktransactionToAdd.StockTransactionType;
                            dbStockTransaction.SharePrice = stocktransactionToAdd.SharePrice;
                            dbStockTransaction.QuantityShares = stocktransactionToAdd.QuantityShares;
                            dbStockTransaction.StockTXNDate = stocktransactionToAdd.StockTXNDate;
                            db.Update(dbStockTransaction);
                            db.SaveChanges();
                            intStockTransactionsAdded += 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    String msg = "  Repositories added:" + intStockTransactionsAdded + "; Error on " + strStockTransaction;
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
