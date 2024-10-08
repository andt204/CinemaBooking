using CinemaBooking.Data;

namespace CinemaBooking.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(CinemaBookingContext context) : base(context)
    {
    }
}