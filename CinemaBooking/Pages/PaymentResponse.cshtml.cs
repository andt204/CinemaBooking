using CinemaBooking.Services;
using CinemaBooking.VnPayModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages;

public class PaymentResponse : PageModel
{
    private readonly VnPayService _vnPayService;

    public PaymentResponse(VnPayService vnPayService)
    {
        _vnPayService = vnPayService;
    }

    [BindProperty]
    public string PaymentStatus { get; set; }

    // public void OnGet()
    // {
    //     var vnp_ResponseCode = Request.Query["vnp_ResponseCode"];
    //     PaymentStatus = _vnPayService.GetPaymentStatus(vnp_ResponseCode);
    // }
}