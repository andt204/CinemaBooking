using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using System.Threading.Tasks;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Authorization;
using CinemaBooking.Data;
using CinemaBooking.Helper;

namespace CinemaBooking.Pages.Customer.Booking {
    [Authorize(Roles = "Customer")]
    public class CinemaSelectionModel : PageModel {
		private readonly CinemaSelectionService _cinemaSelectionService;
        private readonly CinemaBookingContext _context = new CinemaBookingContext();
        [BindProperty]
        public Data.Account account { get; set; }
        // Property to hold the movie data
        public MovieDto Movie { get; set; }
		public List<TheaterDto> Theaters { get; set; } = new List<TheaterDto>();

		// Constructor injection for the service
		public CinemaSelectionModel(CinemaSelectionService cinemaSelectionService) {
			_cinemaSelectionService = cinemaSelectionService;
			Movie = new MovieDto(); 
		}

		public async Task OnGet(int movieId)
		{
			// Check if movieId is valid
			var token = Request.Cookies["jwtToken"];
			if (token != null)
			{
				var email = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
				if (email != null)
				{
					account = _context.Accounts.FirstOrDefault(x => x.AccountId == Int32.Parse(email));
					ViewData["Account"] = account; // Truyền dữ liệu account vào ViewData
				}
			}
			if (movieId <= 0)
			{
				// Handle invalid movieId case
				Movie = new MovieDto
				{
					Title = "Unknown",
					PublishTime = DateTime.MinValue,
					Length = 0,
					DirectorName = "Unknown",
					Country = "Unknown",
					Categories = new List<string>(), // Ensure it's initialized
					Actors = new List<string>(),     // Ensure it's initialized
					Image = null
				};

				// Set string representations for default values
				Movie.CategoriesAsString = string.Join(", ", Movie.Categories);
				Movie.ActorsAsString = string.Join(", ", Movie.Actors);
				return; // Exit the method early
			}

			// Call the service to get the movie details
			var movie = await _cinemaSelectionService.GetMovieByIdAsync(movieId);

			TempData["MovieId"] = movieId;

			if (movie != null)
			{
				// Map properties from the retrieved movie to the MovieDto
				Movie.PublishTime = movie.PublishTime;
				Movie.Length = movie.Length;
				Movie.Title = movie.Title;
				Movie.AgeLimit = movie.AgeLimit;
				Movie.DirectorName = movie.DirectorName;
				Movie.Country = movie.Country;
				Movie.Image = movie.Image;

				// Initialize Categories and Actors lists
				Movie.Categories = movie.Categories ?? new List<string>();
				Movie.Actors = movie.Actors ?? new List<string>();

				// Set the string representations for categories and actors
				Movie.CategoriesAsString = string.Join(", ", Movie.Categories);
				Movie.ActorsAsString = string.Join(", ", Movie.Actors);
			}
			else
			{
				// Handle the case where the movie is null
				Movie = new MovieDto
				{
					Title = "Unknown",
					PublishTime = DateTime.MinValue,
					Length = 0,
					DirectorName = "Unknown",
					Country = "Unknown",
					Categories = new List<string>(), // Ensure it's initialized
					Actors = new List<string>(),     // Ensure it's initialized
					Image = null
				};

				// Set string representations for default values
				Movie.CategoriesAsString = string.Join(", ", Movie.Categories);
				Movie.ActorsAsString = string.Join(", ", Movie.Actors);
			}
			Theaters = await _cinemaSelectionService.GetListTheaterAsync(movieId);
		}
	}
}
