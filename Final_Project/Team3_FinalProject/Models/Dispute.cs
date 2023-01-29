using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Team3_FinalProject.Models
{
    public enum Status { Submitted, Accepted, Rejected, Adjusted }
    public class Dispute
    {
        public Int32 DisputeID { get; set; }

        [Display(Name = "Status")]
        public Status DisputeStatus { get; set; }

        [Display(Name = "Comment")]
        [Required(ErrorMessage ="Dispute comment is required!")]
        public String DisputeComment { get; set; }

        [Display(Name = "Admin Comment")]
        public String AdminComment { get; set; }

        [Display(Name = "Correct Amount")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal CorrectAmount { get; set; }

        [Display(Name = "This transaction should be deleted?")]
        public Boolean DeleteTransaction { get; set; }

        public Transaction Transaction { get; set; }
    }
}

