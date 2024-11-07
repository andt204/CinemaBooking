using CinemaBooking.Data;

namespace CinemaBooking.Repositories;

public interface IAccountRepository :  IBaseRepository<Account>
{
    Task<List<Account>> GetByNameAsync(string name);
    
}