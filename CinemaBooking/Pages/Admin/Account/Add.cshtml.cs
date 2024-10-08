using CinemaBooking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Pages.Admin.Account;

public class Add : PageModel
{
    private readonly CinemaBookingContext _context;

    // public Add(CinemaBookingContext context)
    // {
    //     _context = context;
    // }
    //
    // // ViewModel containing account information and list of roles
    // public class AccountViewModel
    // {
    //     public Data.Account Account { get; set; }
    //     public List<SelectListItem> Roles { get; set; }
    // }
    //
    // [BindProperty]
    // public AccountViewModel Input { get; set; }
    //
    // public async Task<IActionResult> OnGetAsync()
    // {
    //     // Retrieve the list of roles from the database
    //     var roles = await _context.Roles.ToListAsync();
    //
    //     Input = new AccountViewModel
    //     {
    //         Roles = roles.Select(r => new SelectListItem
    //         {
    //             Value = r.RoleId.ToString(),
    //             Text = r.RoleName
    //         }).ToList()
    //     };
    //
    //     return Page();
    // }
    //
    // public async Task<IActionResult> OnPostAsync()
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         // If the model is not valid, reload the list of roles
    //         var roles = await _context.Roles.ToListAsync();
    //         Input.Roles = roles.Select(r => new SelectListItem
    //         {
    //             Value = r.RoleId.ToString(),
    //             Text = r.RoleName
    //         }).ToList();
    //
    //         return Page();
    //     }
    //
    //     // Add the account to the database
    //     _context.Accounts.Add(Input.Account);
    //     await _context.SaveChangesAsync();
    //
    //     return RedirectToPage("/Admin/Account/List"); // Change the path if needed
    // }
}
