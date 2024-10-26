using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int? MovieId { get; set; }
        public int? PostId { get; set; }
        public int AccountId { get; set; }
        public byte? Status { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public byte CommentType { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Movie? Movie { get; set; }
        public virtual Post? Post { get; set; }
    }
}
