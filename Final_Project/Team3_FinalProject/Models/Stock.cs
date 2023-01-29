using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Team3_FinalProject.Models
{
    public class Stock
    {
        public Int32 StockID { get; set; }

        [Display(Name = "Stock Name")]
        [Required(ErrorMessage = "Stock name is required!")]
        public String StockName { get; set; }

        [Display(Name = "Ticker Symbol")]
        [Required(ErrorMessage = "Ticker symbol is required!")]
        public String TickerSymbol { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal StockPrice { get; set; }

        public List<StockTransaction> StockTransactions { get; set; }
        public StockType StockType { get; set; }

        public Stock()
        {
            if (StockTransactions == null)
            {
                StockTransactions = new List<StockTransaction>();
            }
        }
    }
}

