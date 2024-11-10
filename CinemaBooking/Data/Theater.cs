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
        public string TheaterName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public byte Status { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
