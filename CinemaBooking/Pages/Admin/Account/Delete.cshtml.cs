using CinemaBooking.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Admin.Account;

public class Delete : PageModel
{
    private readonly IAccountRepository _accountRepository;

    public Delete(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    [BindProperty] public int Id { get; set; }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        if (id <= 0)
        {
            return NotFound();
        }

        var account = await _accountRepository.GetByIdAsync(id);

        if (account == null)
        {
            return NotFound();
        }

        await _accountRepository.DeleteAsync(id);

        return RedirectToPage("/Admin/Account/List");
    }
}

