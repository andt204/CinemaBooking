using CinemaBooking.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Pages.Admin.Account;

public class List : PageModel
{
   private readonly CinemaBookingContext _context;

   public List(CinemaBookingContext context)
   {
       _context = context;
   }
   public List<Data.Account> Accounts { get; set; }
   
    public async Task OnGetAsync()
        {
            Accounts = await _context.Accounts.ToListAsync();
        }
}