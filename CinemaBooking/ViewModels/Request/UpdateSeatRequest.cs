using CinemaBooking.Enum;

namespace CinemaBooking.ViewModels.Request
{
    public class UpdateSeatRequest
    {
        public int RoomId { get; set; }
        public string Row { get; set; }
        public int Column { get; set; }
        public SeatStatus Status { get; set; } 
        public int SeatTypeId { get; set; }
    }

}
