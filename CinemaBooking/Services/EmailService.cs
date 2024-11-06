using System.Net;
using System.Net.Mail;

namespace CinemaBooking.Services;

public class EmailService : IEmailService
{
    private readonly string _smtpServer = "smtp.example.com"; // Thay bằng SMTP server của bạn
    private readonly string _smtpUser = "your-email@example.com"; // Tài khoản gửi email
    private readonly string _smtpPassword = "your-email-password"; // Mật khẩu email

    public void SendEmail(string to, string subject, string body)
    {
        var message = new MailMessage
        {
            From = new MailAddress(_smtpUser),
            Subject = subject,
            Body = body,
            IsBodyHtml = true
        };
        message.To.Add(to);

        using (var client = new SmtpClient(_smtpServer))
        {
            client.Credentials = new NetworkCredential(_smtpUser, _smtpPassword);
            client.Send(message);
        }
    }
}