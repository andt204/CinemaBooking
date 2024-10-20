using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Actor
    {
        public Actor()
        {
            ActorMovieAssignments = new HashSet<ActorMovieAssignment>();
        }

        public int ActorId { get; set; }
        public string ActorName { get; set; } = null!;

        public virtual ICollection<ActorMovieAssignment> ActorMovieAssignments { get; set; }
    }
}
