using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Team3_FinalProject.Models
{
    public enum StockTransactionType { Purchase, Sell}
    public class StockTransaction
    {
        public const Int32 PURCHASE_FEE = 10;
        public const Int32 SELL_FEE = 15;

        public Int32 StockTransactionID { get; set; }

        public StockTransactionType StockTransactionType { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Quantity is required!")]
        public Int32 QuantityShares { get; set; }

        [Display(Name = "Share Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal SharePrice { get; set; }

        [Display(Name = "Note")]
        public String Note { get; set; }

        [Display(Name = "Amount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal StockTXNAmount { get; set; }

        public void CalcStockPurchase()
        {
            StockTXNAmount = QuantityShares * SharePrice;
        }


        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StockTXNDate { get; set; }

        public StockPortfolio StockPortfolio { get; set; }
        public Stock Stock { get; set; }
    }
}

