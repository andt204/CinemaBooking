using CinemaBooking.Data;
using CinemaBooking.Enum;
using System.Collections.Generic;

namespace CinemaBooking.ViewModels
{
    public class RoomDto
    {
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomName { get; set; } = null!;
        public RoomStatus Status { get; set; }

        public RoomTypeDto RoomType { get; set; } = null!;

        public TheaterDto Theater { get; set; } = null!;

        public List<SeatDto> Seats { get; set; } = new List<SeatDto>();
    }
}
