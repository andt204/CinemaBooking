using CinemaBooking.Data;
using CinemaBooking.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Admin.Account;
[Authorize(Roles = "Admin")]
public class List : PageModel
{
    private readonly IAccountRepository _accountRepository;
    private readonly CinemaBookingContext _context;

    public List(IAccountRepository accountRepository, CinemaBookingContext context)
    {
        _accountRepository = accountRepository;
        _context = context;
    }

    public IEnumerable<Data.Account> Accounts { get; set; }

    public string name { get; set; }

    public async Task OnGetAsync(string? name)
    {
        if (name != null)
        {
            Accounts = await _accountRepository.GetByNameAsync(name);
        }
        else
        {
            Accounts = await _accountRepository.GetListAsync();
        }
    }

    public async Task<IActionResult> OnPostAsync(int id)        
    {
        var account = await _context.Accounts.FindAsync(id);
        Console.WriteLine($"id: {id}");
        if (account != null)
        {
            if (account != null)
            {
                // Toggle the status between Active (1) and Inactive (2)
                account.Status = (byte)(account.Status == 1 ? 2 : 1);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = account.Status == 1 ? "Account activated successfully!" : "Account deactivated successfully!";
            }
        }
        else
        {
            TempData["ErrorMessage"] = "Account not found!";
        }

        return RedirectToPage();
    }
}