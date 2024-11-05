using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaBooking.Services;
using CinemaBooking.ViewModels;
using System.Threading.Tasks;
using CinemaBooking.Data;
using Microsoft.EntityFrameworkCore;
using CinemaBooking.ViewModels.Request;

namespace CinemaBooking.Pages.Customer.CinemaSelection
{
    public class SeatSelectionModel : BasePageCustomerModel
    {
        private readonly SeatSelectionService _seatSelectionService;

        // Property to hold the showtime details
        public ShowtimeDto Showtime { get; set; }

        // Inject the service via constructor
        public SeatSelectionModel(SeatSelectionService seatSelectionService)
        {
            _seatSelectionService = seatSelectionService;
        }

        public async Task<IActionResult> OnGet(int showtimeId)
        {
            LoadUserClaims();
            // Fetch the showtime details including the seats
            Showtime = await _seatSelectionService.GetShowtimeById(showtimeId);
			TempData["RoomId"] = Showtime.RoomId;
			// Check if the showtime is null (e.g., invalid showtimeId)
			if (Showtime == null)
            {
                return NotFound(); // or handle it in another way
            }

            return Page();
        }

        public async Task<IActionResult> OnPostConfirmSelection(CreateUserTicketRequest request)
        {
            request.MovieId = TempData["MovieId"] as int?;
			request.RoomId = TempData["RoomId"] as int?;
			// Call the service to create the ticket
			var ticket = await _seatSelectionService.CreateCustomerTicket(request);
			TempData["TicketMovieAssignmentId"] = ticket.TicketMovieAssignments
                .Where(x => x.TicketId == ticket.TicketId)
                .Select(x => x.TicketMovieId)
                .FirstOrDefault();
			// Redirect to the payment page or show success message
			return Redirect($"/Customer/Payment/Payment/{ticket.TicketId}");
		}
    }
}
