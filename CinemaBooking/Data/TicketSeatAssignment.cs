using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class TicketSeatAssignment
    {
        public int TicketSeatId { get; set; }
        public int TicketId { get; set; }
        public int SeatId { get; set; }

        public virtual Seat Seat { get; set; } = null!;
        public virtual Ticket Ticket { get; set; } = null!;
    }
}
