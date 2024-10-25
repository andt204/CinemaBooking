using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CinemaBooking.Validation
{
    public class PasswordValidation
    {
        public static ValidationResult ValidatePassword(string password, ValidationContext context)
        {
            // Kiểm tra nếu password rỗng hoặc null
            if (string.IsNullOrEmpty(password))
            {
                return new ValidationResult("Password is required.");
            }

            // Kiểm tra độ dài mật khẩu ít nhất 8 ký tự
            if (password.Length < 8)
            {
                return new ValidationResult("Password must be at least 8 characters long.");
            }

            // Biểu thức chính quy để kiểm tra có ít nhất 1 ký tự viết hoa và 1 ký tự là số
            var regex = new Regex(@"^(?=.*[A-Z])(?=.*\d).{8,}$");
            if (!regex.IsMatch(password))
            {
                return new ValidationResult("Password must contain at least one uppercase letter and one digit.");
            }

            // Nếu tất cả kiểm tra đều thành công
            return ValidationResult.Success;
        }
    }
}
