namespace CinemaBooking.ViewModels.Request
{
    public class CreateUserTicketRequest
    {
        public int AccountId { get; set; }
        public int ShowtimeId { get; set; }
        public decimal TicketPrice { get; set; }
        public string SeatIds { get; set; }
        public int? MovieId { get; set; }
		public int? RoomId { get; set; }
	}
}
