namespace CinemaBooking.ViewModels;

public class PaymentDto
{
    public int TicketId { get; set; }
    public string Title { get; set; }
    public string TheaterName { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan StartHour { get; set; }
    public decimal? TicketPrice { get; set; }
    public int Length { get; set; }  
    public string? Image { get; set; }
    public string? ImageBackground { get; set; }  
}