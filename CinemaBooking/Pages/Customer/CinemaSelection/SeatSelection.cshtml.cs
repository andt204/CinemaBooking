using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using System.Threading.Tasks;

namespace CinemaBooking.Pages.Customer.CinemaSelection
{
    public class SeatSelectionModel : PageModel
    {
        private readonly SeatSelectionService _seatSelectionService;

        // Property to hold the showtime details
        public ShowtimeDto Showtime { get; set; }

        // Inject the service via constructor
        public SeatSelectionModel(SeatSelectionService seatSelectionService)
        {
            _seatSelectionService = seatSelectionService;
        }

        public async Task<IActionResult> OnGetAsync(int showtimeId)
        {
            // Fetch the showtime details including the seats
            Showtime = await _seatSelectionService.GetShowtimeById(showtimeId);

            // Check if the showtime is null (e.g., invalid showtimeId)
            if (Showtime == null)
            {
                return NotFound(); // or handle it in another way
            }

            return Page();
        }
    }
}
