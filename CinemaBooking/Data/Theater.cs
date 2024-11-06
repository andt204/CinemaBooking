using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Theater
    {
        public Theater()
        {
            Rooms = new HashSet<Room>();
        }

        public int TheaterId { get; set; }
        public string? TheaterName { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
