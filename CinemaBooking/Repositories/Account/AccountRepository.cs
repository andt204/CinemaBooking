using CinemaBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace CinemaBooking.Repositories;

public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    private readonly CinemaBookingContext _context;
    public AccountRepository(CinemaBookingContext context) : base(context)
    {
        _context = context;
    }
    public async Task<List<Account>> GetByNameAsync(string name)
    {
        return await _context.Accounts
            .Where(a => a.FullName.Contains(name))
            .ToListAsync();
    }
     
}