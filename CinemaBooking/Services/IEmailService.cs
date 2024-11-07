using CinemaBooking.EmailModels;

namespace CinemaBooking.Services;

public interface IEmailService
{
    void ForgotPassword(string email);
}