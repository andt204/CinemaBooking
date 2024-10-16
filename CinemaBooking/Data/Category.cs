using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Category
    {
        public Category()
        {
            Movies = new HashSet<Movie>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
