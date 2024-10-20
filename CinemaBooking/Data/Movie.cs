using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Movie
    {
        public Movie()
        {
            ActorMovieAssignments = new HashSet<ActorMovieAssignment>();
            Comments = new HashSet<Comment>();
            MovieCategoryAssignments = new HashSet<MovieCategoryAssignment>();
            ShowtimeMovieAssignments = new HashSet<ShowtimeMovieAssignment>();
            TicketMovieAssignments = new HashSet<TicketMovieAssignment>();
            Votes = new HashSet<Vote>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; } = null!;
        public int Length { get; set; }
        public string? Description { get; set; }
        public int AgeLimit { get; set; }
        public string? WarningText { get; set; }
        public DateTime PublishTime { get; set; }
        public string? Country { get; set; }
        public string? Image { get; set; }
        public string? ImageBackground { get; set; }
        public byte Status { get; set; }
        public int DirectorId { get; set; }
        public string VideoTrailer { get; set; } = null!;

        public virtual Director Director { get; set; } = null!;
        public virtual ICollection<ActorMovieAssignment> ActorMovieAssignments { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<MovieCategoryAssignment> MovieCategoryAssignments { get; set; }
        public virtual ICollection<ShowtimeMovieAssignment> ShowtimeMovieAssignments { get; set; }
        public virtual ICollection<TicketMovieAssignment> TicketMovieAssignments { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
