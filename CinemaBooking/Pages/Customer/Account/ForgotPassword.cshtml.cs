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
    private readonly CinemaBookingContext _context;

    public ForgotPassword(IEmailService emailService, CinemaBookingContext context)
    {
        _emailService = emailService;
        _context = context;
    }


    [BindProperty] public string Email { get; set; }
    public string Message { get; set; }

    public void Onget()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        var account = _context.Accounts.FirstOrDefault(a => a.Email == Email);
        Console.WriteLine(account);
        if (account == null)
        {
            TempData["ErrorMessage"] = "Account not found";
            return Page();
        }

        UserEmailOptions options = new UserEmailOptions
        {
            ToEmails = new List<string>()
            {
                "no-reply@cinemabooking.com"
            }
        };
        await _emailService.SendTestEmail(options);
        string newPassword = "bdha#2A21d";
        account.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        _context.Update(account);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Reset Password successful";
        return Page();
    }
}