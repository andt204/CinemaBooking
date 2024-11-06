using CinemaBooking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Admin.Director
{
    public class CreateModel : PageModel
    {
        private readonly CinemaBookingContext _context;

        public CreateModel(CinemaBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string DirectorName { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var director = new Data.Director { DirectorName = DirectorName };
            _context.Directors.Add(director);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Admin/Movie/Create");
        }
    }
}
