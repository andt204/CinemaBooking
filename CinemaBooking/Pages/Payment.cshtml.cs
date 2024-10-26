using CinemaBooking.Services;
using CinemaBooking.VnPayModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages;

public class Payment : PageModel
{
    private readonly VnPayService _vnPayService;

    public Payment(VnPayService vnPayService)
    {
        _vnPayService = vnPayService;
    }
    
    

    [BindProperty] public int Amount { get; set; }

    public IActionResult OnPost()
    {
       
      
    }
}