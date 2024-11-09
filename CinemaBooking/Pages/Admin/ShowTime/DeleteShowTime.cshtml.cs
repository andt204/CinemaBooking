using CinemaBooking.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Pages.Admin.ShowTime
{
    [Authorize(Roles = "Admin")]
    public class DeleteShowTimeModel : PageModel
    {
        private CinemaBookingContext _context = new CinemaBookingContext();
        [BindProperty]
        public int ShowtimeId { get; set; }
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            // Check for valid ShowtimeId
            if (ShowtimeId <= 0)
            {
                return BadRequest(new { success = false, message = "Invalid showtime ID." });
            }

            var showtime = await _context.Showtimes.FindAsync(ShowtimeId);
            if (showtime == null)
            {
                return NotFound(new { success = false, message = "Showtime not found." });
            }

            _context.Showtimes.Remove(showtime);
            await _context.SaveChangesAsync();

            return new JsonResult(new { success = true, message = "Showtime deleted successfully!" });
        }

    }
}
