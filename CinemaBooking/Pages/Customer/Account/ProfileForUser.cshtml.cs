using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaBooking.Data;
using CinemaBooking.Helper;
using Microsoft.EntityFrameworkCore;
namespace CinemaBooking.Pages.Customer.Account
{
    [Authorize(Roles = "Customer")]
    public class ProfileForUserModel : PageModel
    {
        CinemaBookingContext context;
        [BindProperty]
        public Data.Account account { get; set; }
        public void OnGet()
        {
            context = new CinemaBookingContext();
            var token = Request.Cookies["jwtToken"];
            if (token != null)
            {
                var email = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
                if (email != null)
                {
                    account = context.Accounts.FirstOrDefault(x => x.Email == email);
                    ViewData["Account"] = account; // Truyền dữ liệu account vào ViewData
                }
            }
        }

    }
}
