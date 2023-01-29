using Team3_FinalProject.DAL;
using System;
using System.Linq;


namespace Team3_FinalProject.Utilities
{
    public static class GenerateNextAccountNumber
    {
        public static UInt32 GetNextAccountNumber(AppDbContext _context)
        {
            //set a constant to designate where the account numbers 
            //should start
            const UInt32 START_NUMBER = 2290000000;

            UInt32 intMaxAccountNumber; //the current maximum course number
            UInt32 intNextAccountNumber; //the course number for the next class

            if (_context.Accounts.Count() == 0) //there are no accounts in the database yet
            {
                intMaxAccountNumber = START_NUMBER; //account numbers start at 101
            }
            else
            {
                intMaxAccountNumber = _context.Accounts.Max(c => c.AccountNo); //this is the highest number in the database right now
            }

            //You added records to the datbase before you realized 
            //that you needed this and now you have numbers less than 100 
            //in the database
            if (intMaxAccountNumber < START_NUMBER)
            {
                intMaxAccountNumber = START_NUMBER;
            }

            //add one to the current max to find the next one
            intNextAccountNumber = intMaxAccountNumber + 1;

            //return the value
            return intNextAccountNumber;
        }

    }
}

