namespace CinemaBooking.Services;

public interface IUserService
{
    Task<string> GetUserByEmailAsync(string email);
        Task<string> GeneratePasswordResetTokenAsync(string email);
        Task<bool> SendPasswordResetEmailAsync(string email);
    
}