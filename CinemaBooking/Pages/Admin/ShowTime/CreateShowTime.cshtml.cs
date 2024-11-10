using CinemaBooking.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CinemaBooking.Pages.Admin.ShowTime
{
    [Authorize(Roles = "Admin")]
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
                .Include(t => t.Rooms.Where(r => r.Status == 0)) // Filter rooms with status == 0
                .ToList();

            Rooms = _context.Rooms
                .Where(r => r.Status == 0) // Get only rooms where status == 0
                .ToList();

            Showtimes = _context.Showtimes
                .Include(s => s.Movie)
                .Include(s => s.Room)
                .ToList();

            Movies = _context.Movies.ToList();

       
                foreach (var cinema in Cinemas)
            {
                foreach (var room in cinema.Rooms)
                {
                    room.Theater = null; // Break reference from Room back to Theater to prevent circular references
                }
            }

            Showtimes.ForEach(showtime =>
            {
                if (showtime.Room != null)
                {
                    showtime.Room.Showtimes = null; // Break reference from Room to Showtimes
                }
                if (showtime.Movie != null)
                {
                    showtime.Movie.Showtimes = null; // Break reference from Movie to Showtimes
                }
            });
        }

        //public void OnGet()
        //{
        //    // Retrieve data from the database with necessary navigation properties included
        //    Cinemas = _context.Theaters
        //        .Include(t => t.Rooms)
        //        .ToList();

        //    Rooms = _context.Rooms.ToList();
        //    Showtimes = _context.Showtimes.Include(s => s.Movie).ToList();
        //    Movies = _context.Movies.ToList();

        //    // Remove circular references by setting related properties to null
        //    foreach (var cinema in Cinemas)
        //    {
        //        foreach (var room in cinema.Rooms)
        //        {
        //            room.Theater = null; // Break reference from Room back to Theater to prevent circular references
        //        }
        //    }

        //    foreach (var showtime in Showtimes)
        //    {
        //        if (showtime.Room != null)
        //        {
        //            showtime.Room.Showtimes = null; // Break reference from Room to Showtimes to avoid circular references
        //        }
        //        if (showtime.Movie != null)
        //        {
        //            showtime.Movie.Showtimes = null; // Break reference from Movie to Showtimes if necessary
        //        }
        //    }

        //}


        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(bool isAuto)
        {

            var movie = _context.Movies.FirstOrDefault(x => x.MovieId == MovieId);
            // Tính thời gian kết thúc của suất chiếu mới
            if ( !isAuto)
            {
               
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
                // Check if StartHour is within operating hours
           

                // Calculate the end time for the new showtime
                var newShowtimeEnd = StartHour.Add(TimeSpan.FromMinutes(movie.Length + 20));

                // Fetch other showtimes in the same room and on the same day
                var existingShowtimes = await _context.Showtimes
                    .Where(s => s.RoomId == RoomId && s.Date == Date)
                    .Include(s => s.Movie)
                    .ToListAsync();

                // Check for time conflicts
                foreach (var showtime in existingShowtimes)
                {
                    var existingShowtimeEnd = showtime.StartHour.Add(TimeSpan.FromMinutes(showtime.Movie.Length + 20));

                    if ((StartHour >= showtime.StartHour && StartHour < existingShowtimeEnd) || // New start overlaps existing showtime
                        (newShowtimeEnd > showtime.StartHour && newShowtimeEnd <= existingShowtimeEnd) || // New end overlaps existing showtime
                        (StartHour <= showtime.StartHour && newShowtimeEnd >= existingShowtimeEnd)) // New showtime fully encompasses existing showtime
                    {
                        // Include details of the conflicting showtime in the error message
                        string conflictMessage = $"Showtime conflicts with another scheduled time: {showtime.Movie.Title} from {showtime.StartHour:hh\\:mm} to {existingShowtimeEnd:hh\\:mm}.";
                        return BadRequest(new { success = false, message = conflictMessage });
                    }
                }

                // If no conflict, add the new showtime
                var newShowtime = new Showtime
                {
                    RoomId = RoomId,
                    MovieId = MovieId,
                    Date = Date,
                    StartHour = StartHour // Set StartHour to null if auto mode
                };

                _context.Showtimes.Add(newShowtime);
                await _context.SaveChangesAsync();

                return new JsonResult(new { success = true, message = "Showtime added successfully!" });
            }
            else
            {
                // Auto mode: Generate multiple showtimes from 9:00 AM to 2:00 AM
                var startTime = new TimeSpan(9, 0, 0); // Start from 9:00 AM
                var endTimeLimit = new TimeSpan(2, 0, 0); // End at 2:00 AM next day
                var lastStartTime = new TimeSpan(23, 59, 0); // Latest possible start time at 11:59 PM

                // List to store new showtimes for batch insertion
                var newShowtimes = new List<Showtime>();
                var currentStartTime = startTime;

                while (currentStartTime <= lastStartTime)
                {
                    // Calculate end time for the current showtime
                    var newShowtimeEnd = currentStartTime.Add(TimeSpan.FromMinutes(movie.Length + 20)); // 20-min break included

                    // Fetch existing showtimes on the same date and room for conflict checking
                    var existingShowtimes = await _context.Showtimes
                        .Where(s => s.RoomId == RoomId && s.Date == Date)
                        .Include(s => s.Movie)
                        .ToListAsync();

                    // Check for conflicts with existing showtimes
                    bool hasConflict = false;
                    foreach (var showtime in existingShowtimes)
                    {
                        var existingShowtimeEnd = showtime.StartHour.Add(TimeSpan.FromMinutes(showtime.Movie.Length + 20));
                        if ((currentStartTime >= showtime.StartHour && currentStartTime < existingShowtimeEnd) ||
                            (newShowtimeEnd > showtime.StartHour && newShowtimeEnd <= existingShowtimeEnd) ||
                            (currentStartTime <= showtime.StartHour && newShowtimeEnd >= existingShowtimeEnd))
                        {
                            // Conflict detected, move start time to end of conflicting showtime + 5 minutes
                            currentStartTime = existingShowtimeEnd.Add(TimeSpan.FromMinutes(5));
                            hasConflict = true;
                            break;
                        }
                    }

                    // If no conflict, create a new showtime for this slot
                    if (!hasConflict)
                    {
                        newShowtimes.Add(new Showtime
                        {
                            RoomId = RoomId,
                            MovieId = MovieId,
                            Date = Date,
                            StartHour = currentStartTime
                        });

                        // Update start time for the next slot with 5-min setup time
                        currentStartTime = newShowtimeEnd.Add(TimeSpan.FromMinutes(5));
                    }
                }

                // Batch insert new showtimes if there are any
                if (newShowtimes.Any())
                {
                    _context.Showtimes.AddRange(newShowtimes);
                    await _context.SaveChangesAsync();
                }

                return new JsonResult(new { success = true, message = $"{newShowtimes.Count} showtimes added successfully!" });
            }

        }
    }
}

