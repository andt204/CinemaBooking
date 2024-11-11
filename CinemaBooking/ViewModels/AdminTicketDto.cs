public class AdminTicketDto
{
    public int TicketId { get; set; }
    public string MovieName { get; set; }
    public string CustomerName { get; set; }
    public List<string> SeatInfo { get; set; } = new List<string>(); // List of seat info
    public decimal TicketPrice { get; set; }
    public string Status { get; set; }
    public DateTime BookingTime { get; set; }
    public DateTime ShowDate { get; set; }
    public TimeSpan ShowTime { get; set; }
    public string RoomName { get; set; }
}
