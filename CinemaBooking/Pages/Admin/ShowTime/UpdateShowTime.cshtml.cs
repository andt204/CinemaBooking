using CinemaBooking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace CinemaBooking.Pages.Admin.ShowTime
{
    [Authorize(Roles = "Admin")]
    public class UpdateShowTimeModel : PageModel
    {
        private readonly CinemaBookingContext _context;

        public UpdateShowTimeModel(CinemaBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int ShowtimeId { get; set; }

        [BindProperty]
        public int RoomId { get; set; }

        [BindProperty]
        public int MovieId { get; set; } // Đảm bảo MovieId được truyền từ client

        [BindProperty]
        public TimeSpan StartHour { get; set; }

        [BindProperty]
        public DateTime Date { get; set; }
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            var movie = await _context.Movies.FindAsync(MovieId);
            if (movie == null)
            {
                return BadRequest(new { success = false, message = "Invalid movie selection." });
            }

            // Kiểm tra RoomId và MovieId hợp lệ
            if (RoomId <= 0 || MovieId <= 0)
            {
                return BadRequest(new { success = false, message = "Invalid room or movie selection." });
            }

            // Kiểm tra StartHour không được là 8:59 hoặc 0:00
            if (StartHour < new TimeSpan(9, 0, 0) || StartHour > new TimeSpan(23, 59, 0))
            {
                return BadRequest(new { success = false, message = "Invalid start time. Please choose a time between 9:00 AM and 11:59 PM." });
            }

            // Tính thời gian kết thúc của suất chiếu mới
            var newShowtimeEnd = StartHour.Add(TimeSpan.FromMinutes(movie.Length + 20));

            // Lấy các suất chiếu khác trong cùng phòng và cùng ngày, ngoại trừ suất chiếu hiện tại
            var existingShowtimes = await _context.Showtimes
                .Where(s => s.RoomId == RoomId && s.Date == Date && s.ShowtimeId != ShowtimeId)
                .Include(s => s.Movie) // Include Movie để lấy Length
                .ToListAsync();

            // Kiểm tra xung đột thời gian
            foreach (var showtime in existingShowtimes)
            {
                var existingShowtimeEnd = showtime.StartHour.Add(TimeSpan.FromMinutes(showtime.Movie.Length));

                if ((StartHour >= showtime.StartHour && StartHour < existingShowtimeEnd) || // New start overlaps existing showtime
                    (newShowtimeEnd > showtime.StartHour && newShowtimeEnd <= existingShowtimeEnd) || // New end overlaps existing showtime
                    (StartHour <= showtime.StartHour && newShowtimeEnd >= existingShowtimeEnd)) // New showtime fully encompasses existing showtime
                {
                    // Include details of the conflicting showtime in the error message
                    string conflictMessage = $"Showtime conflicts with another scheduled time: {showtime.Movie.Title} from {showtime.StartHour:hh\\:mm} to {existingShowtimeEnd:hh\\:mm}.";
                    return BadRequest(new { success = false, message = conflictMessage });
                }
            }

            // Cập nhật thông tin suất chiếu nếu không có xung đột
            var updateShowtime = await _context.Showtimes.FindAsync(ShowtimeId);
            if (updateShowtime == null)
            {
                return NotFound(new { success = false, message = "Showtime not found." });
            }

            updateShowtime.RoomId = RoomId;
            updateShowtime.MovieId = MovieId;
            updateShowtime.StartHour = StartHour;
            updateShowtime.Date = Date;

            _context.Showtimes.Update(updateShowtime);
            await _context.SaveChangesAsync();

            return new JsonResult(new { success = true, message = "Showtime updated successfully!" });
        }
    }
}
