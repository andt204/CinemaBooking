using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;
using CinemaBooking.Data;
using CinemaBooking.EmailModels;
using CinemaBooking.Helper;

namespace CinemaBooking.Services;

public class EmailService : IEmailService
{
    private readonly CinemaBookingContext _context;
    private readonly EmailSettings _emailSettings;
    public EmailService(CinemaBookingContext context, IOptions<EmailSettings> emailSettings)
    {
        _context     = context;
        _emailSettings = emailSettings.Value ;
    }

    public void SendNewPasswordByEmail(string email, string newPassword)
    {
     
        var message = new MimeMessage();
      
        message.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
        message.To.Add(new MailboxAddress("", email));
        message.Subject = "Khôi phục mật khẩu";
        message.Body = new TextPart("plain")
        {
            Text = $"Mật khẩu mới của bạn là: {newPassword}"
        };
        if (message != null)
        {
            Console.WriteLine(message);
        }
        else
        {
            Console.WriteLine("null roi");
        }
        try
        {
            using (var client = new SmtpClient())
            {
                client.Connect(_emailSettings.SmtpServer, _emailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate(_emailSettings.Username, _emailSettings.Password);
                client.Send(message);
                client.Disconnect(true);
            }
        }
        catch (Exception ex)
        {
            // In ra lỗi nếu kết nối SMTP hoặc gửi email thất bại
            Console.WriteLine($"Lỗi khi gửi email: {ex.Message}");
            throw new Exception("Có lỗi khi gửi email khôi phục mật khẩu.");
        }
    }

    public void ForgotPassword(string email)
    {
        // Lấy thông tin tài khoản từ Database
        var account = _context.Accounts.FirstOrDefault(a => a.Email == email);
        if (account == null)
        {
            throw new Exception("Không tìm thấy tài khoản với email đã cung cấp.");
        }

        // Tạo mật khẩu mới
        var newPassword = PasswordGenerator.GeneratePassword(8);

        // Mã hóa mật khẩu mới (nếu cần)
        account.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        _context.SaveChanges();

        // Gửi mật khẩu mới qua email
       

        SendNewPasswordByEmail(email, newPassword);
    }
}

