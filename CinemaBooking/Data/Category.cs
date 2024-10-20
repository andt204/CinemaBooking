using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Category
    {
        public Category()
        {
            MovieCategoryAssignments = new HashSet<MovieCategoryAssignment>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<MovieCategoryAssignment> MovieCategoryAssignments { get; set; }
    }
}
