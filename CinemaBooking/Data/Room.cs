using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Room
    {
        public Room()
        {
            Seats = new HashSet<Seat>();
            Showtimes = new HashSet<Showtime>();
        }

        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public int TheaterId { get; set; }
        public string RoomName { get; set; } = null!;
        public byte Status { get; set; }

        public virtual RoomType RoomType { get; set; } = null!;
        public virtual Theater Theater { get; set; } = null!;
        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<Showtime> Showtimes { get; set; }
    }
}
