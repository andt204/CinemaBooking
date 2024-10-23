using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaBooking.Services; 
using CinemaBooking.ViewModels; 
using System.Threading.Tasks;

namespace CinemaBooking.Pages.Customer.Booking {
	public class CinemaSelectionModel : PageModel {
		private readonly CinemaSelectionService _cinemaSelectionService;

		// Property to hold the movie data
		public MovieDto Movie { get; set; } // Change this to match your data structure

		// Constructor injection for the service
		public CinemaSelectionModel(CinemaSelectionService cinemaSelectionService) {
			_cinemaSelectionService = cinemaSelectionService;
		}

		public async Task OnGet(int movieId) {
			// Call the service to get the movie details
			Movie = await _cinemaSelectionService.GetMovieByIdAsync(movieId);

			// Optional: Handle the case where the movie is null
			if (Movie == null) {
				// You can choose to set default values or redirect to an error page
				Movie = new MovieDto {
					Title = "Unknown",
					PublishTime = DateTime.MinValue,
					Length = 0,
					DirectorName = "Unknown",
					Country = "Unknown",
					Categories = new List<string>(),
					Actors = new List<string>(),
					Image = null
				};
			}
		}
	}
}
