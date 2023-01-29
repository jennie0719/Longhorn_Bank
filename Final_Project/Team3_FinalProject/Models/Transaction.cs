using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Team3_FinalProject.Models
{
    public enum TransactionType { Deposit, Withdrawal, Transfer, Fee}
    public class Transaction
    {
        public Int32 TransactionID { get; set; }

        [Display(Name = "Transaction Number")]
        public Int32 TransactionNumber { get; set; }

        [Display(Name = "Amount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Required(ErrorMessage = "Transaction amount is required!")]
        [Range(0.01,double.PositiveInfinity,ErrorMessage ="Please deposit/withdraw/transfer more than $0.")]
        public Decimal TransactionAmount { get; set; }

        [Display(Name = "Description")]
        public String TransactionDescription { get; set; }

        [Display(Name = "Type")]
        public TransactionType TransactionType { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Comment")]
        public String TransactionComment { get; set; }

        [Display(Name = "Transaction Status")]
        public Boolean Approved { get; set; }

        public List<Dispute> Disputes { get; set; }
        public Account Account { get; set; }

        public Transaction()
        {
            if (Disputes == null)
            {
                Disputes = new List<Dispute>();
            }
        }
    }
}

