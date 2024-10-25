namespace CinemaBooking.Validation
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class EmailValidation
    {
        // Custom validation method for email
        public static ValidationResult ValidateEmail(string email, ValidationContext context)
        {
            // Kiểm tra nếu email rỗng hoặc null
            if (string.IsNullOrEmpty(email))
            {
                return new ValidationResult("Email is required.");
            }

            // Biểu thức chính quy để kiểm tra định dạng email
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!emailRegex.IsMatch(email))
            {
                return new ValidationResult("Invalid email format.");
            }

            // Nếu tất cả kiểm tra đều thành công
            return ValidationResult.Success;
        }
    }

}
