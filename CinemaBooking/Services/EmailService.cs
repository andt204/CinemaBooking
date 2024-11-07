using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using CinemaBooking.EmailModels;

namespace CinemaBooking.Services;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;
   public EmailService(IOptions<SmtpSettings> smtpSettings)
    {
        _smtpSettings = smtpSettings.Value;
    }
    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        using (var client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port))
        {
            client.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
            client.EnableSsl = true;

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.FromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            await client.SendMailAsync(mailMessage);
        }
    }
}