using CinemaBooking.Data;
using CinemaBooking.Enum;

namespace CinemaBooking.ViewModels
{
    public class SeatDto
    {
        public int SeatId { get; set; }
        public int SeatTypeId { get; set; }
        public int RoomId { get; set; }
        public string Row { get; set; }
        public int Column { get; set; }
        public SeatStatus Status { get; set; }
        public SeatTypeDto SeatType { get; set; } = null!;
    }
}
