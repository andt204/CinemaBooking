using System;
using System.Collections.Generic;

namespace CinemaBooking.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Comments = new HashSet<Comment>();
            ShowtimeMovieAssignments = new HashSet<ShowtimeMovieAssignment>();
            TicketMovieAssignments = new HashSet<TicketMovieAssignment>();
            Votes = new HashSet<Vote>();
            Actors = new HashSet<Actor>();
            Categories = new HashSet<Category>();
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
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ShowtimeMovieAssignment> ShowtimeMovieAssignments { get; set; }
        public virtual ICollection<TicketMovieAssignment> TicketMovieAssignments { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
