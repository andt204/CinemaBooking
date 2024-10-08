using CinemaBooking.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Admin.Account;

public class List : PageModel 
{
   private readonly IAccountRepository _accountRepository;
   public List(IAccountRepository accountRepository)
   {
     _accountRepository = accountRepository;
   }
   public IEnumerable<Data.Account> Accounts { get; set; }
   
   
    // public async Task OnGetAsync()
    // {
    //     Accounts = await _accountRepository.GetListAsync();
    // }
    public  void OnGet()
    {
        //Accounts =  _context.Accounts.ToList();
    }
}