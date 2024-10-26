using CinemaBooking.Enum;

namespace CinemaBooking.ViewModels
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public int AccountId { get; set; }
        public int ShowtimeId { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime BookingTime { get; set; }
        public decimal? TicketPrice { get; set; }
        public List<SeatDto> Seats { get; set; }
        public ShowtimeDto Showtime { get; set; }
    }
}
