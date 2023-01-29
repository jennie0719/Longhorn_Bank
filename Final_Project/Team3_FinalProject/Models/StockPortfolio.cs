using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Team3_FinalProject.Models
{
    public class StockPortfolio
    {
        public Int32 StockPortfolioID { get; set; }

        // accountNo accountName
        [Display(Name = "Account Number")]
        public UInt32 AccountNo{get;set;}

        [Display(Name = "Account Name")]
        public String AccountName { get; set; }

        [Display(Name = "Cash-Value Portion")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal CashValuePortion { get; set; }

        [Display(Name = "Stock Portion")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal StockPortion { get; set; }

        [Display(Name = "Total Value")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal TotalValue { get; set; }

        public void CalcTotalValue()
        {
            TotalValue = CashValuePortion + StockPortion;
        }

        [Display(Name = "Bonus")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal Bonus { get; set; }

        [Display(Name = "Balanced")]
        public Boolean Balanced { get; set; }

        [Display(Name = "Approved")]
        public Boolean Approved { get; set; }

        public List<StockTransaction> StockTransactions { get; set; }
        public AppUser AppUser { get; set; }

        public StockPortfolio()
        {
            if (StockTransactions == null)
            {
                StockTransactions = new List<StockTransaction>();
            }
        }
    }
}

