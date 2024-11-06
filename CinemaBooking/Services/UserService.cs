namespace CinemaBooking.Services;

public class UserService : IUserService
{
    private readonly IEmailSender _emailSender;
    private readonly ILogger<UserService> _logger;

    public UserService(IEmailSender emailSender, ILogger<UserService> logger)
    {
        _emailSender = emailSender;
        _logger = logger;
    }

    // Tìm người dùng theo email (giả sử dữ liệu người dùng được lưu trong cơ sở dữ liệu)
    public async Task<string> GetUserByEmailAsync(string email)
    {
        // Đây là nơi bạn sẽ kiểm tra người dùng trong cơ sở dữ liệu
        // Ví dụ trả về email giả lập nếu tìm thấy
        if (email == "user@example.com")
        {
            return email;
        }

        return null; // Không tìm thấy người dùng
    }

    // Tạo mã reset mật khẩu giả lập (có thể thay bằng token thực tế trong cơ sở dữ liệu)
    public async Task<string> GeneratePasswordResetTokenAsync(string email)
    {
        // Mã token giả lập
        var token = Guid.NewGuid().ToString();
        return token;
    }

    // Gửi email chứa liên kết reset mật khẩu
    public async Task<bool> SendPasswordResetEmailAsync(string email)
    {
        try
        {
            // Kiểm tra xem email có tồn tại trong hệ thống không
            var user = await GetUserByEmailAsync(email);
            if (user == null)
            {
                _logger.LogError($"No user found with email: {email}");
                return false;
            }

            // Tạo mã reset mật khẩu
            var resetToken = await GeneratePasswordResetTokenAsync(email);
            var resetLink = $"https://your-website.com/reset-password?token={resetToken}";

            // Tạo thông điệp email
            var message = $"Hi, <br/>Click <a href='{resetLink}'>here</a> to reset your password.";

            // Gửi email
            await _emailSender.SendEmailAsync(email, "Password Reset Request", message);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error sending password reset email: {ex.Message}");
            return false;
        }
    }
}