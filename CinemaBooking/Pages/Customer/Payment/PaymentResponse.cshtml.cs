using CinemaBooking.Services;
using CinemaBooking.VnPayModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages;

public class PaymentResponse : PageModel
{
    private readonly IVnPayService _vnPayService;

    public PaymentResponse(IVnPayService vnPayService)
    {
        _vnPayService = vnPayService;
    }

    public VnPaymentResponseModel PaymentResponseModel { get; set; }

    public void OnGet()
    {
        var response = _vnPayService.MakePayment(Request.Query);

        if (response != null)
        {
            PaymentResponseModel = response;
        }
        Console.Write($"ticketid: {PaymentResponseModel.TicketId}");
    }
}