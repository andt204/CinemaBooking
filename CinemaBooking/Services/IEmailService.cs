using CinemaBooking.EmailModels;

namespace CinemaBooking.Services;

public interface IEmailService
{
    Task SendTestEmail(UserEmailOptions userEmailOptions);
    Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);

    Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions);

}