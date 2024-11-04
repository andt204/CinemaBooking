using CinemaBooking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Admin.Actor
{
    public class CreateModel : PageModel
    {
        private readonly CinemaBookingContext _context;

        public CreateModel(CinemaBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string ActorName { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var actor = new Data.Actor { ActorName = ActorName };
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Admin/Movie/Create");
        }
    }
} 
