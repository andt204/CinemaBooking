using CinemaBooking.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Customer.Account;

public class ForgotPassword : PageModel
{
    private readonly IEmailService _emailService; // Giả sử bạn đã tạo một dịch vụ gửi email
    private readonly IUserService _userService; // Dịch vụ để lấy người dùng từ email

    public ForgotPassword(IEmailService emailService, IUserService userService)
    {
        _emailService = emailService;
        _userService = userService;
    }

    [BindProperty]
    public string Email { get; set; }

    public IActionResult OnPost()
    {
        if (string.IsNullOrEmpty(Email))
        {
            ModelState.AddModelError(string.Empty, "Email không hợp lệ.");
            return Page();
        }

        var user = _userService.GetUserByEmail(Email);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Email không tồn tại.");
            return Page();
        }

        var newPassword = _userService.GenerateNewPassword(user); // Hàm tạo mật khẩu mới

        // Gửi email chứa mật khẩu mới
        var emailContent = $"Mật khẩu mới của bạn là: {newPassword}";
        _emailService.SendEmail(Email, "Mật khẩu mới", emailContent);

        return RedirectToPage("/Account/ResetPasswordConfirmation"); // Trang xác nhận
    }
}