using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Team3_FinalProject.DAL;
using Team3_FinalProject.Models;

namespace Team3_FinalProject.Seeding
{
    public class SeedStocks
    {
        public static void SeedAllStocks(AppDbContext db)
        { 
            Int32 intStocksAdded = 0;
            String strStocksTitle = "Begin";
            try
            {


                List<Stock> Stocks = new List<Stock>();

                Stock s1 = new Stock()
                {
                    TickerSymbol = "GOOG",
                    StockName = "Alphabet Inc.",
                    StockPrice = 87.07m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Ordinary");
                Stocks.Add(s1);

                Stock s2 = new Stock()
                {
                    TickerSymbol = "AAPL",
                    StockName = "Apple Inc.",
                    StockPrice = 145.03m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Ordinary");
                Stocks.Add(s2);

                Stock s3 = new Stock()
                {
                    TickerSymbol = "AMZN",
                    StockName = "Amazon.com Inc.",
                    StockPrice = 92.12m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Ordinary");
                Stocks.Add(s3);

                Stock s4 = new Stock()
                {
                    TickerSymbol = "LUV",
                    StockName = "Southwest Airlines",
                    StockPrice = 36.50m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Ordinary");
                Stocks.Add(s4);

                Stock s5 = new Stock()
                {
                    TickerSymbol = "TXN",
                    StockName = "Texas Instruments",
                    StockPrice = 158.49m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Ordinary");
                Stocks.Add(s5);

                Stock s6 = new Stock()
                {
                    TickerSymbol = "HSY",
                    StockName = "The Hershey Company",
                    StockPrice = 235.11m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Ordinary");
                Stocks.Add(s6);

                Stock s7 = new Stock()
                {
                    TickerSymbol = "V",
                    StockName = "Visa Inc.",
                    StockPrice = 200.95m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Ordinary");
                Stocks.Add(s7);

                Stock s8 = new Stock()
                {
                    TickerSymbol = "NKE",
                    StockName = "Nike",
                    StockPrice = 90.3m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Ordinary");
                Stocks.Add(s8);

                Stock s9 = new Stock()
                {
                    TickerSymbol = "VWO",
                    StockName = "Vanguard Emerging Markets ETF",
                    StockPrice = 35.77m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "ETF");
                Stocks.Add(s9);

                Stock s10 = new Stock()
                {
                    TickerSymbol = "CORN",
                    StockName = "Corn",
                    StockPrice = 27.35m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Futures");
                Stocks.Add(s10);

                Stock s11 = new Stock()
                {
                    TickerSymbol = " FXAIX",
                    StockName = " Fidelity 500 Index Fund",
                    StockPrice = 133.88m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Mutual Fund");
                Stocks.Add(s11);


                Stock s12 = new Stock()
                {
                    TickerSymbol = " F",
                    StockName = " Ford Motor Company",
                    StockPrice = 13.06m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Ordinary");
                Stocks.Add(s12);


                Stock s13 = new Stock()
                {
                    TickerSymbol = "BAC",
                    StockName = "Bank of America Corporation",
                    StockPrice = 36.09m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Ordinary");
                Stocks.Add(s13);


                Stock s14 = new Stock()
                {
                    TickerSymbol = "VNQ",
                    StockName = "Vanguard REIT ETF",
                    StockPrice = 80.67m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "ETF");
                Stocks.Add(s14);


                Stock s15 = new Stock()
                {
                    TickerSymbol = "NSDQ",
                    StockName = "Nasdaq Index Fund",
                    StockPrice = 10524.8m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Index Fund");
                Stocks.Add(s15);


                Stock s16 = new Stock()
                {
                    TickerSymbol = "KMX",
                    StockName = "CarMax, Inc.",
                    StockPrice = 62.36m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Ordinary");
                Stocks.Add(s16);


                Stock s17 = new Stock()
                {
                    TickerSymbol = "DIA",
                    StockName = "Dow Jones Industrial Average Index Fund",
                    StockPrice = 321.36m


                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Index Fund");
                Stocks.Add(s17);


                Stock s18 = new Stock()
                {
                    TickerSymbol = "SPY",
                    StockName = "S&P 500 Index Fund",
                    StockPrice = 374.87m

                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Index Fund");
                Stocks.Add(s18);



                Stock s19 = new Stock()
                {
                    TickerSymbol = "BEN",
                    StockName = "Franklin Resources, Inc.",
                    StockPrice = 22.56m

                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == "Ordinary");
                Stocks.Add(s19);


                Stock s20 = new Stock()
                {
                    TickerSymbol = " FLCEX",
                    StockName = " Fidelity Large Cap Core Enhanced Index Fund",
                    StockPrice = 18.1m

                };
                s1.StockType = db.StockTypes.FirstOrDefault(st => st.StockTypeName == " Mutual Fund");
                Stocks.Add(s20);



                try
                {
                    foreach (Stock stockToAdd in Stocks)
                    {
                        strStocksTitle = stockToAdd.StockName;
                        Stock dbStock = db.Stocks.FirstOrDefault(b => b.StockName == stockToAdd.StockName);
                        if (dbStock == null) //this title doesn't exist
                        {
                            db.Stocks.Add(stockToAdd);
                            db.SaveChanges();
                            intStocksAdded += 1;
                        }
                        else //property exists - update values
                        {
                            dbStock.TickerSymbol = stockToAdd.TickerSymbol;
                            dbStock.StockName = stockToAdd.StockName;
                            dbStock.StockPrice = stockToAdd.StockPrice;                         
                            db.Update(dbStock);
                            db.SaveChanges();
                            intStocksAdded += 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    String msg = "  Repositories added:" + intStocksAdded + "; Error on " + strStocksTitle;
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
