﻿using System;
using System.Collections.Generic;

namespace CinemaBooking.Models
{
    public partial class Room
    {
        public Room()
        {
            Seats = new HashSet<Seat>();
            TicketMovieAssignments = new HashSet<TicketMovieAssignment>();
        }

        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomName { get; set; } = null!;
        public byte Status { get; set; }

        public virtual RoomType RoomType { get; set; } = null!;
        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<TicketMovieAssignment> TicketMovieAssignments { get; set; }
    }
}