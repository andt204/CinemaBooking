using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int MovieId { get; set; }
        public int AccountId { get; set; }
        public string Status { get; set; } = null!;
        public string Content { get; set; } = null!;

        public virtual Account Account { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
