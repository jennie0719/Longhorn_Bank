using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace Team3_FinalProject.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name="First Name")]
        [Required(ErrorMessage = "First name is required!")]
        public String FirstName { get; set; }

        [Display(Name = "Middle Initial")]
        [RegularExpression(@"^[A-Z]+$", ErrorMessage = "Use letters only please")]
        [MaxLength(1, ErrorMessage ="Use one letter only")]
        public String MI { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required!")]
        public String LastName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required!")]
        public String Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required!")]
        public String City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required!")]
        public String State { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Zip code is required!")]
        [Range(10000,99999,ErrorMessage ="Please enter valid zip code!")]
        public Int32 ZipCode { get; set; }

        //[Display(Name = "SSN")]
        //[Required(ErrorMessage = "SSN is required!")]
        //public Int32 SSN { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Date of birth is required!")]
        public DateTime DOB { get; set; }

        [Display(Name = "Disabled")]
        public Boolean Disabled { get; set; }

        public List<Account> Accounts { get; set; }
        public StockPortfolio StockPortfolio { get; set; }

        public AppUser()
        {
            if (Accounts == null)
            {
                Accounts = new List<Account>();
            }
        }
    }
}
