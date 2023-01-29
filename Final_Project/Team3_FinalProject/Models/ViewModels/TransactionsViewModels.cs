using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;


namespace Team3_FinalProject.Models
{
    public enum TransferFeeType { Add, Include }
    //NOTE: This is the view model used to register a user
    //When the user registers, they only need to specify the
    //properties listed in this model
    public class TransferViewModel
    {
        //NOTE: Here is the property for email
        [Display(Name = "From Account")]
        public int FromAccount { get; set; }

        //NOTE: Here is the property for phone number
        [Display(Name = "To Account")]
        public int ToAccount { get; set; }

        //Add any fields that you need for creating a new user
        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Amount is required!")]
        [Range(0.01, double.PositiveInfinity, ErrorMessage = "Amount must be more than $0.01")]
        public Decimal TransferAmount { get; set; }

        [Display(Name = "Transfer Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Transfer Date is required!")]
        public DateTime TransferDate { get; set; }

        public Boolean TransferFromIRA { get; set; }

        [Display(Name = "Transfer Fee Type")]
        public TransferFeeType IRATransferFeeType { get; set; }
    }

    public enum SortOrder { Ascending, Descending }
    public enum SortBy { Date, Number, Type, Description, Amount }
    public class SearchViewModel
    {
        public int? SelectedAccount { get; set; }

        [Display(Name = "Search by Description:")]
        public String SearchDescription { get; set; }

        [Display(Name = "Search by Transaction Type:")]
        public TransactionType? SearchTransactionType { get; set; }

        [Display(Name = "Search by Amount Range:")]
        public Decimal? SearchMinAmount { get; set; }
        public Decimal? SearchMaxAmount { get; set; }

        [Display(Name = "Search by Transaction Number:")]
        public Int32? SearchTransactionNumber { get; set; }

        [Display(Name = "Search by Date Range:")]
        [DataType(DataType.Date)]
        public DateTime? SearchMinDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? SearchMaxDate { get; set; }

        [Display(Name = "Sort By:")]
        public SortBy SearchSortBy { get; set; }

        [Display(Name = "Order By:")]
        public SortOrder SearchSortOrder { get; set; }
    }
}
