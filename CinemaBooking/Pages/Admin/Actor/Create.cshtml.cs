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
        [BindProperty]
        public int ActorId { get; set; } // Used to identify the actor for update/delete

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
            if (await _context.Actors.AnyAsync(a => a.ActorName == ActorName))
            {
                ModelState.AddModelError(string.Empty, "This actor already exists!"); // Add error message to ModelState
                
            }

            var actor = new Data.Actor { ActorName = ActorName };
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Actor has been successfully added!";
            return RedirectToPage();
        }
        // Method to update an existing actor
        public async Task<IActionResult> OnPostUpdateAsync()
        {
            var actor = await _context.Actors.FindAsync(ActorId);
            if (actor == null)
            {
                ModelState.AddModelError("", "Actor not found.");
                return Page();
            }

            actor.ActorName = ActorName;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Actor updated successfully!";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if (actor != null)
            {
                _context.Actors.Remove(actor);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Actor deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Actor not found.";
            }

            return RedirectToPage();
        }
    }
}
