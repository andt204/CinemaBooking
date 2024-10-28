using CinemaBooking.Services;
using CinemaBooking.VnPayModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages;

public class Payment : PageModel
{
    private readonly IVnPayService _vnPayService;

    public Payment(IVnPayService vnPayService)
    {
        _vnPayService = vnPayService;
    }

    [BindProperty]
    public VnPaymentRequestModel PaymentRequest { get; set; }

    public VnPaymentResponseModel PaymentResponse { get; set; }

    public void OnGet()
    {
            
    }

    public IActionResult OnPost() 
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        PaymentRequest.OrderId = "1";
        PaymentRequest.CreatedDate = DateTime.Now;

        return Redirect(_vnPayService.CreatePaymentUrl(HttpContext, PaymentRequest));
    }
}