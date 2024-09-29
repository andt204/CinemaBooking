using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Actor
    {
        public Actor()
        {
            Movies = new HashSet<Movie>();
        }

        public int ActorId { get; set; }
        public string ActorName { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
