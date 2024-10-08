using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaBooking.Data;
using Microsoft.EntityFrameworkCore; // Adjust the namespace as per your project structure

namespace CinemaBooking.Pages.Admin.Account
{
    public class Edit : PageModel
    {
        private readonly CinemaBookingContext _context; // Your DbContext

        // public Edit(CinemaBookingContext context)
        // {
        //     _context = context;
        // }
        //
        // [BindProperty]
        // public Data.Account Model { get; set; } // Account model for binding
        //
        // public List<Role> Roles { get; set; } // List of roles to populate the dropdown
        //
        // public async Task<IActionResult> OnGetAsync(int id)
        // {
        //     // Load the account details from the database using the provided ID
        //     Model = await _context.Accounts.FindAsync(id);
        //
        //     if (Model == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     // Load roles from the database
        //     Roles = await _context.Roles.ToListAsync();
        //
        //     return Page();
        // }
        //
        // public async Task<IActionResult> OnPostAsync(IFormFile avatar)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         // If the model state is invalid, return the page with the current values
        //         Roles = await _context.Roles.ToListAsync();
        //         return Page();
        //     }
        //
        //     // Retrieve the existing account from the database
        //     var accountToUpdate = await _context.Accounts.FindAsync(Model.AccountId);
        //
        //     if (accountToUpdate == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     // Update the account details
        //     accountToUpdate.Username = Model.Username;
        //     accountToUpdate.Gender = Model.Gender;
        //     accountToUpdate.PhoneNumber = Model.PhoneNumber;
        //     accountToUpdate.DateOfBirth = Model.DateOfBirth;
        //     accountToUpdate.Email = Model.Email;
        //     accountToUpdate.Status = Model.Status;
        //     accountToUpdate.RoleId = Model.RoleId;
        //
        //     // Handle file upload for avatar if provided
        //     if (avatar != null && avatar.Length > 0)
        //     {
        //         // Assuming you save the avatar file to a specific path
        //         var filePath = Path.Combine("wwwroot/uploads", avatar.FileName);
        //         using (var stream = new FileStream(filePath, FileMode.Create))
        //         {
        //             await avatar.CopyToAsync(stream);
        //         }
        //         accountToUpdate.Avatar = avatar.FileName; // Store filename in the database
        //     }
        //
        //     // Save changes to the database
        //     await _context.SaveChangesAsync();
        //
        //     // Redirect to a suitable page after successful update
        //     return RedirectToPage("./Index"); // Adjust the redirect page as needed
        // }
    }
}
