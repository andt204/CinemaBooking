using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Theater
    {
        public Theater()
        {
            Showtimes = new HashSet<Showtime>();
        }

        public int TheaterId { get; set; }
        public string? TheaterName { get; set; }
        public string? Location { get; set; }

        public virtual ICollection<Showtime> Showtimes { get; set; }
    }
}
