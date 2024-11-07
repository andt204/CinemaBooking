using CinemaBooking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CinemaBooking.Pages.Admin.Movie
{
    public class ListMovieModel : PageModel
    {
        private readonly CinemaBookingContext _context;

        public List<Data.Movie> Movies { get; set; }
        public List<Data.Category> Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Title { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Status { get; set; }

        public ListMovieModel(CinemaBookingContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            // Load categories for the dropdown
            Categories = await _context.Categories.ToListAsync();

            // Create a query for movies
            var query = _context.Movies
                                .Include(m => m.Director)
                                .Include(m => m.MovieCategoryAssignments)
                                .ThenInclude(a => a.Category)
                                .AsQueryable();

            // Apply Title filter
            if (!string.IsNullOrEmpty(Title))
            {
                query = query.Where(m => m.Title.Contains(Title));
            }

            // Apply Category filter
            if (CategoryId.HasValue)
            {
                query = query.Where(m => m.MovieCategoryAssignments.Any(a => a.CategoryId == CategoryId.Value));
            }

            // Apply Status filter
            if (!string.IsNullOrEmpty(Status))
            {
                int statusValue = Status == "Released" ? 1 : 2;
                query = query.Where(m => m.Status == statusValue);
            }

            // Execute the query and store the result in Movies
            Movies = await query.ToListAsync();
        }

        // Method to change status of a movie using form POST
        public async Task<IActionResult> OnPost(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                movie.Status = (byte)((movie.Status == 1) ? 2 : 1); // Toggle between 1 and 2
                await _context.SaveChangesAsync();
            }
            return RedirectToPage(); // Redirect to refresh the page
        }
    }
}
