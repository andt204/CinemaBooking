using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class TicketMovieAssignment
    {
        public int TicketMovieId { get; set; }
        public int TicketId { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public virtual Ticket Ticket { get; set; } = null!;
    }
}
