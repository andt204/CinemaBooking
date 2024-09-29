using System;
using System.Collections.Generic;

namespace CinemaBooking.Data
{
    public partial class RoomType
    {
        public RoomType()
        {
            Rooms = new HashSet<Room>();
        }

        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; } = null!;
        public byte Status { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
