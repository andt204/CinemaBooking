using System;
using System.Collections.Generic;

namespace CinemaBooking.Models
{
    public partial class ShowtimeMovieAssignment
    {
        public ShowtimeMovieAssignment()
        {
            TicketMovieAssignments = new HashSet<TicketMovieAssignment>();
        }

        public int ShowtimeMovieId { get; set; }
        public int ShowtimeId { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public virtual Showtime Showtime { get; set; } = null!;
        public virtual ICollection<TicketMovieAssignment> TicketMovieAssignments { get; set; }
    }
}
