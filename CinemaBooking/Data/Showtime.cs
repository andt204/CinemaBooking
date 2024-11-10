using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Showtime
    {
        public Showtime()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int ShowtimeId { get; set; }
        public int RoomId { get; set; }
        public TimeSpan StartHour { get; set; }
        public DateTime Date { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
