using CinemaBooking.Services; // Ensure your service is included
using CinemaBooking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Admin.Seat
{
    public class DeleteSeatsModel : PageModel
    {
        private readonly SeatService _seatService;

        public DeleteSeatsModel(SeatService seatService)
        {
            _seatService = seatService;
        }

        [BindProperty]
        public int SeatId { get; set; }

        public List<SeatDto> SeatsToDelete { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Fetch the seat details based on the ID passed in
            SeatsToDelete = await _seatService.GetSeatsByIdAsync(id);
            if (SeatsToDelete == null || !SeatsToDelete.Any())
            {
                return NotFound(); // Handle if no seats found
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (SeatId <= 0)
            {
                return RedirectToPage("/Admin/Seat/CreateSeats"); // Redirect if SeatId is invalid
            }

            // Call the service to delete the seat
            await _seatService.DeleteSeatAsync(SeatId);

            TempData["SuccessMessage"] = "Seats successfully deleted!";
            return RedirectToPage("/Admin/Seat/CreateSeats"); // Redirect after deletion
        }
    }
}
