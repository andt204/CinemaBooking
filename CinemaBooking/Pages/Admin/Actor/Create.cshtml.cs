using CinemaBooking.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Pages.Admin.Actor
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
        public string ActorName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public List<Data.Actor> ActorList { get; set; }

        public string ErrorMessage { get; private set; }

        public async Task<IActionResult> OnGetAsync(string? title)
        {
            ActorList = string.IsNullOrEmpty(title)
                ? await _context.Actors.ToListAsync()
                : await _context.Actors
                    .Where(a => a.ActorName.Contains(title))
                    .ToListAsync();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            // Check ModelState first
            // if (!ModelState.IsValid)
            //     return Page();

            // Check if the actor already exists
            if (await _context.Actors.AnyAsync(a => a.ActorName == ActorName))
            {
                ModelState.AddModelError(string.Empty, "This actor already exists!"); // Add error message to ModelState
                // return Page();
            }

            var actor = new Data.Actor { ActorName = ActorName };
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Actor has been successfully added!";
            return RedirectToPage();
        }
    }
}
