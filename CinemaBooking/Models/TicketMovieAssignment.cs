using System;
using System.Collections.Generic;

namespace CinemaBooking.Models
{
    public partial class TicketMovieAssignment
    {
        public int TicketMovieId { get; set; }
        public int TicketId { get; set; }
        public int MovieId { get; set; }
        public int RoomId { get; set; }
        public int ShowtimeMovieId { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public virtual Room Room { get; set; } = null!;
        public virtual ShowtimeMovieAssignment ShowtimeMovie { get; set; } = null!;
        public virtual Ticket Ticket { get; set; } = null!;
    }
}
