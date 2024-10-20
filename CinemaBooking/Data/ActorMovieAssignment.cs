using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class ActorMovieAssignment
    {
        public int ActorMovieId { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        public virtual Actor Actor { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
