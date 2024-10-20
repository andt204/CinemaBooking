using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class MovieCategoryAssignment
    {
        public int MovieCategoryId { get; set; }
        public int MovieId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
