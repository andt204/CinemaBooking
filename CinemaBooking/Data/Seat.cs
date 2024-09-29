using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Seat
    {
        public Seat()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int SeatId { get; set; }
        public int SeatTypeId { get; set; }
        public int RoomId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public byte Status { get; set; }

        public virtual Room Room { get; set; } = null!;
        public virtual SeatType SeatType { get; set; } = null!;
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
