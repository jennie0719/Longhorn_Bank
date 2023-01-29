using System.Data;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Team3_FinalProject.DAL;
using Team3_FinalProject.Models;
using Team3_FinalProject.Utilities;
using Team3_FinalProject.SendMail;
using System.Runtime.Intrinsics.Arm;

namespace Team3_FinalProject.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly PasswordValidator<AppUser> _passwordValidator;
        private readonly AppDbContext _context;

        public AccountController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signIn, RoleManager<IdentityRole> roleManager)
        {
            _context = appDbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signIn;
            //user manager only has one password validator
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel rvm)
        {
            //if registration data is valid, create a new user on the database
            if (ModelState.IsValid == false)
            {
                //this is the sad path - something went wrong, 
                //return the user to the register page to try again
                return View(rvm);
            }

            //this code maps the RegisterViewModel to the AppUser domain model
            AppUser newUser = new AppUser
            {
                UserName = rvm.Email,
                Email = rvm.Email,
                PhoneNumber = rvm.PhoneNumber,

                FirstName = rvm.FirstName,
                MI = rvm.MI,
                LastName = rvm.LastName,
                Address = rvm.Address,
                City = rvm.City,
                State = rvm.State,
                ZipCode = rvm.ZipCode,
                DOB = rvm.DOB

            };

            //create AddUserModel
            AddUserModel aum = new AddUserModel()
            {
                User = newUser,
                Password = rvm.Password,

                //TODO: You will need to change this value if you want to 
                //add the user to a different role - just specify the role name.
                RoleName = "Customer"
            };

            //This code uses the AddUser utility to create a new user with the specified password
            IdentityResult result = await Utilities.AddUser.AddUserWithRoleAsync(aum, _userManager, _context);

            if (result.Succeeded) //everything is okay
            { 
                //NOTE: This code logs the user into the account that they just created
                //You may or may not want to log a user in directly after they register - check
                //the business rules!
                Microsoft.AspNetCore.Identity.SignInResult result2 = await _signInManager.PasswordSignInAsync(rvm.Email, rvm.Password, false, lockoutOnFailure: false);
                AppUser userLoggedIn = await _userManager.FindByEmailAsync(rvm.Email);
                userLoggedIn.Disabled = true;

                //Send Email
                String emailSubject = "Welcome to LonghornBank03!";
                String emailBody = @"<div>Hi " + newUser.FirstName + ",</div><br/>";
                emailBody = emailBody + @"<div>Thank you for registering your account with us. </div><br/>";
                emailBody = emailBody + @"<div> Your Username is:</div>" + newUser.Email;
                emailBody = emailBody + @"<br/><div> Hope you have a wondertime with Longhorn Bank!</div><br/>";

                EmailMessaging.SendEmail(rvm.Email, emailSubject, emailBody);



                //Send the user to the home page
                return RedirectToAction("Apply", "Accounts");
            }
            else  //the add user operation didn't work, and we need to show an error message
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send user back to page with errors
                return View(rvm);
            }
        }

        // GET: /Account/RegisterEmployee
        [Authorize(Roles ="Admin")]
        public IActionResult RegisterEmployee()
        {
            return View();
        }

        // POST: /Account/RegisterEmployee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterEmployee(RegisterEmployeeViewModel revm)
        {
            //if registration data is valid, create a new user on the database
            if (ModelState.IsValid == false)
            {
                //this is the sad path - something went wrong, 
                //return the user to the register page to try again
                return View(revm);
            }

            //this code maps the RegisterViewModel to the AppUser domain model
            AppUser newUser = new AppUser
            {
                UserName = revm.Email,
                Email = revm.Email,
                PhoneNumber = revm.PhoneNumber,

                FirstName = revm.FirstName,
                MI = revm.MI,
                LastName = revm.LastName,
                Address = revm.Address,
                City = revm.City,
                State = revm.State,
                ZipCode = revm.ZipCode,
                Disabled = false
            };

            //create AddUserModel
            AddUserModel aum = new AddUserModel()
            {
                User = newUser,
                Password = revm.Password,

                //TODO: You will need to change this value if you want to 
                //add the user to a different role - just specify the role name.
                RoleName = "Employee"
            };

            //This code uses the AddUser utility to create a new user with the specified password
            IdentityResult result = await Utilities.AddUser.AddUserWithRoleAsync(aum, _userManager, _context);

            if (result.Succeeded) //everything is okay
            {
                return RedirectToAction("EmployeeIndex");
            }
            else  //the add user operation didn't work, and we need to show an error message
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send user back to page with errors
                return View(revm);
            }
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel fpvm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(fpvm.EmailAddress);
                if (user == null)
                {
                    return View(fpvm);
                }
                if (user.DOB == fpvm.DOB)
                {
                    //Send Email
                    String emailSubject = "Welcome to LonghornBank03!";
                    String emailBody = @"<div>Hi " + user.FirstName + ",</div><br/>";
                    emailBody = emailBody + @"<div>This is your confirmation link to reset your password: </div><br/>";
                    emailBody = emailBody + @"<a> Account/ChangePassword. </a>";
                    emailBody = emailBody + @"<br/><div> Have fun changing!</div><br/>";

                    EmailMessaging.SendEmail(user.Email, emailSubject, emailBody);
                    return View("Login");
                }
            }
            return View(fpvm);
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated) //user has been redirected here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            _signInManager.SignOutAsync(); //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl; //pass along the page the user should go back to
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel lvm, string returnUrl)
        {
            //if user forgot to include user name or password,
            //send them back to the login page to try again
            if (ModelState.IsValid == false)
            {
                return View(lvm);
            }

            //attempt to sign the user in using the SignInManager
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, lvm.RememberMe, lockoutOnFailure: false);

            //if the login worked, take the user to either the url
            //they requested OR the homepage if there isn't a specific url
            if (result.Succeeded)
            {
                AppUser userLoggedIn = await _userManager.FindByEmailAsync(lvm.Email);

                var role = await _userManager.GetRolesAsync(userLoggedIn);
                var x = role[0];
                if (x == "Customer")
                {
                    if (userLoggedIn.Disabled)
                    {
                        return RedirectToAction("Index");
                    }
                    List<Account> dbAccounts = _context.Accounts
                        .Include(a => a.Transactions)
                        .Where(a => a.AppUser == userLoggedIn).ToList();

                    if (dbAccounts.Count == 0)
                    {
                        return RedirectToAction("Apply", "Accounts");
                    }
                    foreach (var acc in dbAccounts)
                    {
                        if (acc.Transactions.Count() == 0 && acc.Balance == 0)
                        {
                            return RedirectToAction("Transact", "Transactions", new { accountID = acc.AccountID });
                        }
                    }
                    //return ?? "/" means if returnUrl is null, substitute "/" (home)
                    return RedirectToAction("Index", "Accounts");
                }
                else
                {
                    if (userLoggedIn.Disabled)
                    {
                        //add an error to the model to show invalid attempt
                        ModelState.AddModelError("", "Terminated employees can no longer login.");
                        _signInManager.SignOutAsync();
                        //send user back to login page to try again
                        return View(lvm);
                    }
                    return RedirectToAction("StaffHome", "Home");
                }
                
            }
            else //log in was not successful
            {
                //add an error to the model to show invalid attempt
                ModelState.AddModelError("", "Invalid login attempt.");
                //send user back to login page to try again
                return View(lvm);
            }
        }

        public IActionResult AccessDenied()
        {
            return View("Error", new string[] { "You are not authorized for this resource" });
        }

        //GET: Account/Index
        public IActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            //get user info
            String id = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == id);

            //populate the view model
            //(i.e. map the domain model to the view model)
            ivm.Email = user.Email;
            ivm.HasPassword = true;
            ivm.UserID = user.Id;
            ivm.FirstName = user.FirstName;
            ivm.LastName = user.LastName;

            //send data to the view
            return View(ivm);
        }

        [Authorize(Roles = "Employee, Admin")]
        public async Task<ActionResult> CustomerIndex()
        {
            //Set up a list of accounts to display
            List<AppUser> customers = new List<AppUser>();

            //loop through ALL the users and decide if they are in the role(member) or not (non-member)
            foreach (AppUser user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, "Customer") == true) //user is in the role
                {
                    //add user to list of members
                    customers.Add(user);
                }
            }
            //
            return View(customers);
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> EmployeeIndex()
        {
            //Set up a list of accounts to display
            List<AppUser> employees = new List<AppUser>();

            //loop through ALL the users and decide if they are in the role(member) or not (non-member)
            foreach (AppUser user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, "Employee") == true) //user is in the role
                {
                    //add user to list of members
                    employees.Add(user);
                }
            }
            //
            return View(employees);
        }

        //Logic for change password
        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            String id = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == id);

            if (user.Disabled)
            {
                return View("Error", new string[] { "Disabled customer can no longer change password." });
            }
            return View();
        }

        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel cpvm)
        {
            //if user forgot a field, send them back to 
            //change password page to try again
            if (ModelState.IsValid == false)
            {
                return View(cpvm);
            }

            //Find the logged in user using the UserManager
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);

            //Attempt to change the password using the UserManager
            var result = await _userManager.ChangePasswordAsync(userLoggedIn, cpvm.OldPassword, cpvm.NewPassword);

            //if the attempt to change the password worked
            if (result.Succeeded)
            {
                //sign in the user with the new password
                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);

                //send the user back to the profile page
                return RedirectToAction("Index", "Account");
            }
            else //attempt to change the password didn't work
            {
                //Add all the errors from the result to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send the user back to the change password page to try again
                return View(cpvm);
            }
        }

        //Logic for edit profile
        // GET: /Account/EditProfile
        public ActionResult EditProfile()
        {
            EditProfileViewModel epvm = new EditProfileViewModel();

            //get user info
            String id = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == id);

            if (user.Disabled)
            {
                return View("Error", new string[] { "Disabled customer can no longer edit profile." });
            }

            //populate the view model
            //(i.e. map the domain model to the view model)
            epvm.PhoneNumber = user.PhoneNumber;
            epvm.FirstName = user.FirstName;
            epvm.MI = user.MI;
            epvm.LastName = user.LastName;
            epvm.Address = user.Address;
            epvm.City = user.City;
            epvm.State = user.State;
            epvm.ZipCode = user.ZipCode;

            //send data to the view
            return View(epvm);
        }

        // POST: /Account/EditProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditProfile(EditProfileViewModel epvm)
        {
            //if user forgot a field, send them back to 
            //change password page to try again
            if (ModelState.IsValid == false)
            {
                return View(epvm);
            }

            //Find the logged in user using the UserManager
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);

            //Attempt to change the password using the UserManager
            if (User.IsInRole("Customer"))
            {
                userLoggedIn.FirstName = epvm.FirstName;
                userLoggedIn.MI = epvm.MI;
                userLoggedIn.LastName = epvm.LastName;
            }
            
            userLoggedIn.Address = epvm.Address;
            userLoggedIn.City = epvm.City;
            userLoggedIn.State = epvm.State;
            userLoggedIn.ZipCode = epvm.ZipCode;
            userLoggedIn.PhoneNumber = epvm.PhoneNumber;

            var result = await _userManager.UpdateAsync(userLoggedIn);

            //if the attempt to change the password worked
            if (result.Succeeded)
            {
                //sign in the user with the new password
                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);

                //send the user back to the home page
                return RedirectToAction("Index", "Account");
            }
            else //attempt to change the profile didn't work
            {
                //Add all the errors from the result to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send the user back to the change password page to try again
                return View(epvm);
            }
        }

        //Logic for edit profile
        // GET: /Account/EditProfile
        [Authorize(Roles = "Employee, Admin")]
        public ActionResult StaffModify(String id)
        {
            if (id == "" || _context.Users == null)
            {
                return View("Error", new string[] { "Please specify a profile to modify!" });
            }

            StaffModifyViewModel smvm = new StaffModifyViewModel();
            smvm.id = id;

            //get user info
            AppUser user = _context.Users.FirstOrDefault(u => u.Id == id);

            //populate the view model
            //(i.e. map the domain model to the view model)
            smvm.PhoneNumber = user.PhoneNumber;
            smvm.FirstName = user.FirstName;
            smvm.MI = user.MI;
            smvm.LastName = user.LastName;
            smvm.Address = user.Address;
            smvm.City = user.City;
            smvm.State = user.State;
            smvm.ZipCode = user.ZipCode;

            //send data to the view
            return View(smvm);
        }

        // POST: /Account/EditProfile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> StaffModify(String id, StaffModifyViewModel smvm)
        {
            if (id != smvm.id)
            {
                return NotFound();
            }

            //if user forgot a field, send them back to 
            //change password page to try again
            if (ModelState.IsValid == false)
            {
                return View(smvm);
            }

            //Find the logged in user using the UserManager
            AppUser user = _context.Users.FirstOrDefault(u => u.Id == id);

            user.Address = smvm.Address;
            user.City = smvm.City;
            user.State = smvm.State;
            user.ZipCode = smvm.ZipCode;
            user.PhoneNumber = smvm.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            //if the attempt to change the password worked
            if (result.Succeeded)
            {
                if (smvm.NewPassword != null)
                {
                    //TODO: get old password and change user.PasswordHash to that
                    var result2 = await _userManager.ChangePasswordAsync(user, user.PasswordHash, smvm.NewPassword);
                    if (result2.Succeeded)
                    {
                        //TODO: change to direct to the modified user's role index
                        return RedirectToAction("StaffHome", "Home");
                    }
                    return View(smvm);
                }
                return RedirectToAction("StaffHome", "Home");
                
            }
            else //attempt to change the profile didn't work
            {
                //Add all the errors from the result to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send the user back to the change password page to try again
                return View(smvm);
            }
        }

        // GET: Accounts/Inactivate/5
        [Authorize(Roles = "Employee, Admin")]
        public async Task<IActionResult> Disable(String id)
        {
            if (id == null || _context.Users == null)
            {
                return View("Error", new string[] { "Please specify an account to enable/disable!" });
            }

            AppUser user = await _context.Users.FindAsync(id);

            if (user.Disabled)
            {
                ViewBag.CurrentStatus = "Disabled";
                ViewBag.StatusChanged = "Enable";
            }
            else
            {
                ViewBag.CurrentStatus = "Enabled";
                ViewBag.StatusChanged = "Disable";
            }
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Accounts/Inactivate/5
        [HttpPost, ActionName("Disable")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DisableConfirmed(String id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'AppDbContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                AppUser dbUser = _context.Users.Find(id);
                dbUser.Disabled = !user.Disabled;
                _context.Update(dbUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("StaffHome", "Home");
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            //sign the user out of the application
            _signInManager.SignOutAsync();

            //send the user back to the home page
            return RedirectToAction("Index", "Home");
        }           
    }
}