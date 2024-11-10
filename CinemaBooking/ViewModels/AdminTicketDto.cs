namespace CinemaBooking.ViewModels
{
    public class AdminTicketDto
    {
        public int TicketId { get; set; }
        public string MovieName { get; set; }
        public string CustomerName { get; set; }
        public string SeatInfo { get; set; }  // Combined seat row and column
        public decimal TicketPrice { get; set; }
        public string Status { get; set; }
        public DateTime BookingTime { get; set; }
        public DateTime ShowDate { get; set; }
        public TimeSpan ShowTime { get; set; }
        public string RoomName { get; set; }
    }
}