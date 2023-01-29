using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Team3_FinalProject.Models;
using Team3_FinalProject.DAL;

namespace Team3_FinalProject.Seeding
{
    public static class SeedDisputes
    {
        public static void SeedAllDisputes(AppDbContext db)
        {
            if (db.Disputes.Count() == 2)
            {
                throw new NotSupportedException("The database already contains all 21 reviews!");
            }

            Int32 intDisputesAdded = 0;
            String strDispute = "Begin"; //helps to keep track of error on books
            List<Dispute> Disputes = new List<Dispute>();

            try
            {
                Dispute d1 = new Dispute()
                {
                    DisputeComment = "I don’t remember buying so many snacks",
                    CorrectAmount = 300.00m,
                    DisputeStatus = Status.Submitted,
                };
                d1.Transaction = db.Transactions.FirstOrDefault(t => t.TransactionNumber == 8);
                Disputes.Add(d1);

                Dispute d2 = new Dispute()
                {
                    DisputeComment = "You rapscallions are trying to steal my money!!!",
                    CorrectAmount = 0.00m,
                    DisputeStatus = Status.Submitted,
                };
                d2.Transaction = db.Transactions.FirstOrDefault(t => t.TransactionNumber == 10);
                Disputes.Add(d2);





                try
                {
                    foreach (Dispute disputeToAdd in Disputes)
                    {
                        int intDisputeID = disputeToAdd.DisputeID;
                        Dispute dbDispute = db.Disputes.FirstOrDefault(dp => dp.DisputeID == dp.DisputeID); ;
                        if (dbDispute == null) //this title doesn't exist
                        {
                            db.Disputes.Add(disputeToAdd);
                            db.SaveChanges();
                            intDisputesAdded += 1;
                        }
                        else //property exists - update values
                        {

                            dbDispute.CorrectAmount = disputeToAdd.CorrectAmount;
                            dbDispute.DisputeComment = disputeToAdd.DisputeComment;
                            db.Update(dbDispute);
                            db.SaveChanges();
                            intDisputesAdded += 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    String msg = "  Repositories added:" + intDisputesAdded + "; Error on " + strDispute;
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


