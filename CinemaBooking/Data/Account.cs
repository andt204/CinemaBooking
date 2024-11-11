using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class Account
    {
        public Account()
        {
            Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
            Tickets = new HashSet<Ticket>();
            Votes = new HashSet<Vote>();
        }

        public int AccountId { get; set; }
        public string FullName { get; set; } = null!;
        public string? Avatar { get; set; }
        public string Gender { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte Status { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
