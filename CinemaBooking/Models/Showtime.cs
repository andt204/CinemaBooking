﻿using System;
using System.Collections.Generic;

namespace CinemaBooking.Models
{
    public partial class Showtime
    {
        public Showtime()
        {
            ShowtimeMovieAssignments = new HashSet<ShowtimeMovieAssignment>();
        }

        public int ShowtimeId { get; set; }
        public TimeSpan StartHour { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<ShowtimeMovieAssignment> ShowtimeMovieAssignments { get; set; }
    }
}
