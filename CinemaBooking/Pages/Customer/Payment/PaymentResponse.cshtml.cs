using CinemaBooking.Service;
using CinemaBooking.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Customer.Payment;

public class PaymentResponseModel  : PageModel
{
    private readonly IVnPayService _vnPayService;

    public PaymentResponseModel (IVnPayService vnPayService)
    {
        _vnPayService = vnPayService;
    }
    public VnPaymentResponseModel PaymentResponse   { get; set; }
    
    public void OnGet()
    {
        var response = _vnPayService.MakePayment(Request.Query);

        if (response != null)
        {
            PaymentResponse = response;
        }

    }
}