using CinemaBooking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaBooking.Pages.Customer.Movie
{
	public class DetailMovieModel : PageModel
	{
		private readonly CinemaBookingContext _context;

		public DetailMovieModel(CinemaBookingContext context)
		{
			_context = context;
		}

		public Data.Movie Movie { get; set; }
		public List<Showtime> Showtimes { get; set; } = new List<Showtime>(); // List to hold showtimes
		public List<Category> Categories { get; set; } = new List<Category>(); // List to hold categories
        public List<Actor> Actors { get; set; } = new List<Actor>(); // List to hold actors
        public Director Director { get; set; } // To hold director information

        public async Task<IActionResult> OnGetAsync(int movieId) // Using movieId as the parameter
		{
			// Fetch the movie details
			Movie = await _context.Movies.FindAsync(movieId);

			if (Movie == null)
			{
				return NotFound(); // Return 404 if movie not found
			}

			// Fetch showtimes associated with the movie using the ShowtimeMovieAssignments
			Showtimes = await _context.ShowtimeMovieAssignments
				.Where(s => s.MovieId == movieId) // Get assignments for the specific movie
				.Select(s => s.Showtime) // Get the related showtime
				.ToListAsync();

			Categories = await _context.MovieCategoryAssignments
				.Where(mc => mc.MovieId == movieId) // Get assignments for the specific movie
				.Select(mc => mc.Category) // Get the related category
				.ToListAsync();

            Actors = await _context.ActorMovieAssignments
                .Where(am => am.MovieId == movieId)
                .Select(am => am.Actor)
                .ToListAsync();

           Director = await _context.Directors
                .Where(d => d.DirectorId == Movie.DirectorId)
                .FirstOrDefaultAsync();

            return Page(); 
		}
	}
}
