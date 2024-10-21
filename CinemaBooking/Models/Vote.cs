using System;
using System.Collections.Generic;

namespace CinemaBooking.Models
{
    public partial class Vote
    {
        public int VoteId { get; set; }
        public int AccountId { get; set; }
        public int MovieId { get; set; }
        public int Rating { get; set; }
        public DateTime VoteDate { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
