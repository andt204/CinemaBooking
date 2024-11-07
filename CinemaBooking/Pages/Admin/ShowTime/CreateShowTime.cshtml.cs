using CinemaBooking.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CinemaBooking.Pages.Admin.ShowTime
{
    public class CreateShowTimeModel : PageModel
    {
        private readonly CinemaBookingContext _context;

        public CreateShowTimeModel(CinemaBookingContext context)
        {
            _context = context;
        }
        [BindProperty]
        public int RoomId { get; set; }

        [BindProperty]
        public int MovieId { get; set; }

        [BindProperty]
        public TimeSpan StartHour { get; set; }

        [BindProperty]
        public DateTime Date { get; set; }

        public List<Data.Theater> Cinemas { get; set; }
        public List<Data.Room> Rooms { get; set; }
        public List<Showtime> Showtimes { get; set; }
        public List<Data.Movie> Movies { get; set; }

        public void OnGet()
        {
            // Retrieve data from the database with necessary navigation properties included
            Cinemas = _context.Theaters
                .Include(t => t.Rooms)
                .ToList();

            Rooms = _context.Rooms.ToList();
            Showtimes = _context.Showtimes.Include(s => s.Movie).ToList();
            Movies = _context.Movies.ToList();

            // Remove circular references by setting related properties to null
            foreach (var cinema in Cinemas)
            {
                foreach (var room in cinema.Rooms)
                {
                    room.Theater = null; // Break reference from Room back to Theater to prevent circular references
                }
            }

            foreach (var showtime in Showtimes)
            {
                if (showtime.Room != null)
                {
                    showtime.Room.Showtimes = null; // Break reference from Room to Showtimes to avoid circular references
                }
                if (showtime.Movie != null)
                {
                    showtime.Movie.Showtimes = null; // Break reference from Movie to Showtimes if necessary
                }
            }

        }


        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            var movie = _context.Movies.FirstOrDefault(x => x.MovieId == MovieId);
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

            // Lấy các suất chiếu khác trong cùng phòng và cùng ngày
            var existingShowtimes = await _context.Showtimes
    .Where(s => s.RoomId == RoomId && s.Date == Date)
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

            // Nếu không có xung đột, thêm suất chiếu mới
            var newShowtime = new Showtime
            {
                RoomId = RoomId,
                MovieId = MovieId,
                StartHour = StartHour,
                Date = Date
            };

            _context.Showtimes.Add(newShowtime);
            await _context.SaveChangesAsync();

            return new JsonResult(new { success = true, message = "Showtime added successfully!" });
        }
    }
}

