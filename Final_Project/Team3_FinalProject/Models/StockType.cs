using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Team3_FinalProject.Models
{
    public class StockType
    {
        public Int32 StockTypeID { get; set; }

        [Display(Name = "Stock Type Name")]
        [Required(ErrorMessage = "Stock type name is required!")]
        public String StockTypeName { get; set; }

        public List<Stock> Stocks { get; set; }

        public StockType()
        {
            if (Stocks == null)
            {
                Stocks = new List<Stock>();
            }
        }
    }
}

