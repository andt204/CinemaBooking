using CinemaBooking.Repositories;
using CinemaBooking.Repositories.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CinemaBooking.Pages.Customer.Payment
{
    public class PaymentModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMovieRepository _movieRepository;

        public PaymentModel(
            IAccountRepository accountRepository,
            IMovieRepository movieRepository
        )
        {
            _accountRepository = accountRepository;
            _movieRepository = movieRepository;
        }

        public Data.Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Account = await _accountRepository.GetByIdAsync(id);

            return Page();
        }
    }
}