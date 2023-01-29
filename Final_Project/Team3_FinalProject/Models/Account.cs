using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace Team3_FinalProject.Models
{
    public enum AccountType { Savings, Checking, IRA }
    public class Account
    {

        public Int32 AccountID { get; set; }

        [Display(Name = "Account Number")]
        public UInt32 AccountNo { get; set; }

        public string AccountNo4Digits
        {
            get
            {
                return AccountNo.ToString();
            }
        }

        [Display(Name = "Account Type")]
        public AccountType AccountType { get; set; }

        [Display(Name = "Balance")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Balance { get; set; }

        [Display(Name = "Account Name")]
        public String AccountName { get; set; }

        [Display(Name = "Account Status")]
        public Boolean Active { get; set; }

        [Display(Name = "Annual Contribution")]
        public Decimal Contribution { get; set; }

        public List<Transaction> Transactions { get; set; }
        public AppUser AppUser { get; set; }

        public Account()
        {
            if (Transactions == null)
            {
                Transactions = new List<Transaction>();
            }
        }

        public String AccountTransfer
        {
            get
            {
                return AccountName + " - " + AccountNo.ToString()+" - $" + Balance;
            }
        }
    }
}

