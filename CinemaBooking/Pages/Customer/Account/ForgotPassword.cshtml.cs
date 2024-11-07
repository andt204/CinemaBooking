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
    private readonly CinemaBookingContext _context;
    private readonly IEmailService _emailService;

    public ForgotPassword(CinemaBookingContext context, IEmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }


    [BindProperty] public string Email { get; set; }

    public string Message { get; set; }


    public async Task OnPostAsync()
    {
        var user =  _context.Accounts.Where(a => a.Email == Email).FirstOrDefault();

        if (user != null)
        {
            var newPassword = PasswordGenerator.GeneratePassword(8);

            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);

            _context.Accounts.Update(user);

            var subject = "Your new Password";
            var body = $"Your new Password is: {newPassword}";
            await _emailService.SendEmailAsync(user.Email, subject, body);

            Message = "Your password has been sent to your email address";
        }
        else
        {
            Message = "Not found this email address.";
        }
    }
}