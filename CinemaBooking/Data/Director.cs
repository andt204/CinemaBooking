﻿using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        public int DirectorId { get; set; }
        public string DirectorName { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
