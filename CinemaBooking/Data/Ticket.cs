using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Ticket
    {
        public Ticket()
        {
            TicketMovieAssignments = new HashSet<TicketMovieAssignment>();
        }

        public int TicketId { get; set; }
        public int AccountId { get; set; }
        public int ShowtimeId { get; set; }
        public int SeatId { get; set; }
        public byte Status { get; set; }
        public DateTime BookingTime { get; set; }
        public decimal? TicketPrice { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Seat Seat { get; set; } = null!;
        public virtual Showtime Showtime { get; set; } = null!;
        public virtual ICollection<TicketMovieAssignment> TicketMovieAssignments { get; set; }
    }
}
