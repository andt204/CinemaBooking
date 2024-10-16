using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int PostId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int AccountId { get; set; }
        public byte Status { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
