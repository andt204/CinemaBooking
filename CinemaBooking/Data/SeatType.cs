using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class SeatType
    {
        public SeatType()
        {
            Seats = new HashSet<Seat>();
        }

        public int SeatTypeId { get; set; }
        public string SeatTypeName { get; set; } = null!;
        public decimal? SeatPrice { get; set; }

        public virtual ICollection<Seat> Seats { get; set; }
    }
}
