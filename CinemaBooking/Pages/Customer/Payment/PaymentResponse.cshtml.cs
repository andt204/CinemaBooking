using CinemaBooking.Data;
using CinemaBooking.Helper;
using CinemaBooking.Services;
using CinemaBooking.VnPayModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages;

[Authorize(Roles = "Customer")]
public class PaymentResponse : PageModel
{
    private readonly CinemaBookingContext _context =new CinemaBookingContext();
    [BindProperty]
    public Data.Account account { get; set; }

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
            var token = Request.Cookies["jwtToken"];
            if (token != null)
            {
                var email = DecodeJwtToken.DecodeJwtTokenAndGetEmail(token);
                if (email != null)
                {
                    account = _context.Accounts.FirstOrDefault(x => x.AccountId == Int32.Parse(email));
                    ViewData["Account"] = account;
                }
            }
            PaymentResponseModel = response;
        }
        Console.Write($"ticketid: {PaymentResponseModel.TicketId}");
    }
}
