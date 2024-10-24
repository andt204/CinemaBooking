﻿using System;
using System.Collections.Generic;

namespace CinemaBooking.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            TicketMovieAssignments = new HashSet<TicketMovieAssignment>();
        }

        public int TicketId { get; set; }
        public int SeatId { get; set; }
        public int PriceId { get; set; }
        public byte Status { get; set; }
        public DateTime BookingTime { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual TicketPrice Price { get; set; } = null!;
        public virtual Seat Seat { get; set; } = null!;
        public virtual ICollection<TicketMovieAssignment> TicketMovieAssignments { get; set; }
    }
}
