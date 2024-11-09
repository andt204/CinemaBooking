using CinemaBooking.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Pages.Admin.Director
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly CinemaBookingContext _context;

        public CreateModel(CinemaBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string DirectorName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public List<Data.Director> DirectorList { get; set; }

        public string ErrorMessage { get; private set; }

        public async Task<IActionResult> OnGetAsync(string? title)
        {
            DirectorList = string.IsNullOrEmpty(title)
                ? await _context.Directors.ToListAsync()
                : await _context.Directors
                    .Where(a => a.DirectorName.Contains(title))
                    .ToListAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            // Check ModelState first
            // if (!ModelState.IsValid)
            //     return Page();

            // Check if the actor already exists
            if (await _context.Directors.AnyAsync(a => a.DirectorName == DirectorName))
            {
                ModelState.AddModelError(string.Empty, "This director already exists!"); // Add error message to ModelState
                // return Page();
            }

            var actor = new Data.Director { DirectorName = DirectorName };
            _context.Directors.Add(actor);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Director has been successfully added!";
            return RedirectToPage();
        }
    }
}
