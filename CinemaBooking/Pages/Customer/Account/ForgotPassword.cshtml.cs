using CinemaBooking.Data;
using CinemaBooking.EmailModels;
using CinemaBooking.Helper;
using CinemaBooking.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Customer.Account;

public class ForgotPassword : PageModel
{
    private readonly IEmailService _emailService;

    public ForgotPassword( IEmailService emailService)
    {
        _emailService = emailService;
    }


    [BindProperty] public string Email { get; set; }

    public string Message { get; set; }


    public  void  OnPost()
    {
        try
        {
            // Gọi service để xử lý logic quên mật khẩu
            _emailService.ForgotPassword(Email);
            Message = "Mật khẩu mới đã được gửi đến email của bạn.";
        }
        catch (Exception ex)
        {
            Message = $"Có lỗi xảy ra: {ex.Message}";
        }
    } 
}