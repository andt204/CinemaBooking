namespace CinemaBooking.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetListAsync();
    Task<T> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}