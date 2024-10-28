namespace CinemaBooking.VnPayModels;

public class VnPaymentRequestModel
{
    public string OrderId { get; set; } = Guid.NewGuid().ToString();
    public string FullName { get; set; }
    public string Description { get; set; }
    public decimal? Amount { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}