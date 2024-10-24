using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Showtime
    {
        public Showtime()
        {
            ShowtimeMovieAssignments = new HashSet<ShowtimeMovieAssignment>();
            Tickets = new HashSet<Ticket>();
        }

        public int ShowtimeId { get; set; }
        public int TheaterId { get; set; }
        public int RoomId { get; set; }
        public TimeSpan StartHour { get; set; }
        public DateTime Date { get; set; }

        public virtual Room Room { get; set; } = null!;
        public virtual Theater Theater { get; set; } = null!;
        public virtual ICollection<ShowtimeMovieAssignment> ShowtimeMovieAssignments { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
