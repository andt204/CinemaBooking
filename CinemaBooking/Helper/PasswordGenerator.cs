namespace CinemaBooking.Helper;

public class PasswordGenerator
{
    private static Random _random = new Random();

    public static string GeneratePassword(int length = 8)
    {
        const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
        const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string digits = "0123456789";
        const string allChars = lowerCase + upperCase + digits;

        // Đảm bảo mật khẩu có ít nhất 1 chữ hoa và 1 số
        var password = new char[length];

        // Thêm một chữ hoa và một số vào mật khẩu
        password[0] = upperCase[_random.Next(upperCase.Length)];
        password[1] = digits[_random.Next(digits.Length)];

        // Phần còn lại của mật khẩu lấy ngẫu nhiên từ tất cả các ký tự
        for (int i = 2; i < length; i++)
        {
            password[i] = allChars[_random.Next(allChars.Length)];
        }

        // Trộn mật khẩu để các ký tự được phân tán ngẫu nhiên
        password = password.OrderBy(c => _random.Next()).ToArray();

        return new string(password);
    }
}