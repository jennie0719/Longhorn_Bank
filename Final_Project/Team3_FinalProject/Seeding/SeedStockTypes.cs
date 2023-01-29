using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Team3_FinalProject.DAL;
using Team3_FinalProject.Models;

namespace Team3_FinalProject.Seeding
{
    public class SeedStockTypes
    {
        public static void SeedAllStockTypes(AppDbContext db)
        {
            Int32 intStockTypesAdded = 0;
            String strStockTypeName = "Begin";

            List<StockType> StockTypes = new List<StockType>();
            try
            {
                StockType sts1 = new StockType()
                {
                    StockTypeName = "Ordinary",
                };
                StockTypes.Add(sts1);

                StockType sts2 = new StockType()
                {
                    StockTypeName = "ETF",
                };
                StockTypes.Add(sts2);

                StockType sts3 = new StockType()
                {
                    StockTypeName = "Futures",
                };
                StockTypes.Add(sts3);

                StockType sts4 = new StockType()
                {
                    StockTypeName = "Mutual Fund",
                };
                StockTypes.Add(sts4);

                StockType sts5 = new StockType()
                {
                    StockTypeName = "Index Fund",
                };
                StockTypes.Add(sts5);

                try
                {
                    foreach (StockType stocktypeToAdd in StockTypes)
                    {
                        strStockTypeName = stocktypeToAdd.StockTypeName;
                        StockType dbStockType = db.StockTypes.FirstOrDefault(stp => stp.StockTypeName == stp.StockTypeName);
                        if (dbStockType == null) //this title doesn't exist
                        {
                            db.StockTypes.Add(stocktypeToAdd);
                            db.SaveChanges();
                            intStockTypesAdded += 1;
                        }
                        else //property exists - update values
                        {

                            dbStockType.StockTypeName = stocktypeToAdd.StockTypeName;
                           
                            db.Update(dbStockType);
                            db.SaveChanges();
                            intStockTypesAdded += 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    String msg = "  Repositories added:" + intStockTypesAdded + "; Error on " + strStockTypeName;
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

