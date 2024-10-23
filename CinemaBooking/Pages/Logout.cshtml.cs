using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Xóa cookie JWT token
            if (Request.Cookies.ContainsKey("jwtToken"))
            {
                Response.Cookies.Delete("jwtToken");
            }

            // Chuyển hướng về trang đăng nhập (có thể thay thế bằng đường dẫn đúng của bạn)
            return RedirectToPage("/Customer/Account/Login");
        }
    }
}
