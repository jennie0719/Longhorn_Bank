using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;


namespace Team3_FinalProject.Models
{ 
    //NOTE: This is the view model used to allow the user to login
    //The user only needs the email and password to login
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    //NOTE: This is the view model used to register a user
    //When the user registers, they only need to specify the
    //properties listed in this model
    public class RegisterViewModel
    {   
        //NOTE: Here is the property for email
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //NOTE: Here is the property for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        //Add any fields that you need for creating a new user
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required!")]
        public String FirstName { get; set; }

        [Display(Name = "Middle Initial")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [MaxLength(1, ErrorMessage = "Use one letter only")]
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
        [Range(10000, 99999, ErrorMessage = "Please enter valid zip code!")]
        public Int32 ZipCode { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Date of birth is required!")]
        public DateTime DOB { get; set; }

        //NOTE: Here is the logic for putting in a password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterEmployeeViewModel
    {
        //NOTE: Here is the property for email
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //NOTE: Here is the property for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        //Add any fields that you need for creating a new user
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required!")]
        public String FirstName { get; set; }

        [Display(Name = "Middle Initial")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [MaxLength(1, ErrorMessage = "Use one letter only")]
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
        [Range(10000, 99999, ErrorMessage = "Please enter valid zip code!")]
        public Int32 ZipCode { get; set; }

        //NOTE: Here is the logic for putting in a password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    //NOTE: This is the view model used to allow the user to 
    //change their password
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    //NOTE: This is the view model used to allow the user to 
    //edit their profile
    public class EditProfileViewModel
    {
        //NOTE: Here is the property for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //Add any fields that you need for creating a new user
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required!")]
        public String FirstName { get; set; }

        [Display(Name = "Middle Initial")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [MaxLength(1, ErrorMessage = "Use one letter only")]
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
        [Range(10000, 99999, ErrorMessage = "Please enter valid zip code!")]
        public Int32 ZipCode { get; set; }
    }

    //NOTE: This is the view model used to allow the employees/admins to 
    //edit customers/employees profile
    public class StaffModifyViewModel
    {
        public string id { get; set; }

        //NOTE: Here is the property for phone number
        [Required(ErrorMessage = "Phone number is required")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //Add any fields that you need for creating a new user
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required!")]
        public String FirstName { get; set; }

        [Display(Name = "Middle Initial")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        [MaxLength(1, ErrorMessage = "Use one letter only")]
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
        [Range(10000, 99999, ErrorMessage = "Please enter valid zip code!")]
        public Int32 ZipCode { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    //NOTE: This is the view model used to display basic user information
    //on the index page
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String UserID { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Date of Birth is required!")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DOB { get; set; }
    }
}
