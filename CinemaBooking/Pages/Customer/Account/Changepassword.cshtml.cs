using CinemaBooking.Data;
using CinemaBooking.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.Pages.Customer.Account
{
    public class ChangepasswordModel : PageModel
    {
        [BindProperty]
        public ChangePasswordInput Input { get; set; }

        public Data.Account account { get; set; }
        private readonly CinemaBookingContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ChangepasswordModel(CinemaBookingContext context)
        {
            _context = context;
        }

        public class ChangePasswordInput
        {
            [Required(ErrorMessage = "Current Password is required.")]
            public string CurrentPassword { get; set; }

            [Required(ErrorMessage = "New Password is required.")]
            [MinLength(8, ErrorMessage = "New Password must be at least 8 characters long.")]
            [RegularExpression(@"^(?=.*[A-Z])(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$",
                ErrorMessage = "New Password must contain at least one uppercase letter and one special character.")]
            public string NewPassword { get; set; }

            [Required(ErrorMessage = "Confirm Password is required.")]
            [Compare("NewPassword", ErrorMessage = "Confirm Password must match the New Password.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet()
        {
            var token = Request.Cookies["jwtToken"];
            if (token != null)
            {
                var email = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
                if (email != null)
                {
                    account = _context.Accounts.FirstOrDefault(x => x.AccountId == Int32.Parse(email));
                    ViewData["Account"] = account; // Pass account data to ViewData
                }
            }
        }
        [ValidateAntiForgeryToken]
        public IActionResult OnPost()
        {
           

            var token = Request.Cookies["jwtToken"];
            if (token != null)
            {
                var email = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
                if (email != null)
                {
                    account = _context.Accounts.FirstOrDefault(x => x.AccountId == Int32.Parse(email));

                    if (!ModelState.IsValid)
                    {
                        return Page(); // Return the page with validation errors
                    }
                    // Validate the current password
                    if (!BCrypt.Net.BCrypt.Verify(Input.CurrentPassword, account.Password))
                      
                    {
                        ModelState.AddModelError("Input.CurrentPassword", "Current Password is not correct.");
                        return Page();
                    }
                  

                    // Update password (consider hashing before saving)
                    account.Password = BCrypt.Net.BCrypt.HashPassword(Input.NewPassword); // Hash it here before saving in a real scenario
                    _context.SaveChanges();

                    TempData["SuccessMessage"] = "Password changed successfully!";
                    return RedirectToPage("/Customer/Account/ChangePassword");
                }
            }

            ModelState.AddModelError("", "Unauthorized request.");
            return Page();
        }
    }
}
