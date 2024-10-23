using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CinemaBooking.Validation
{
    public class PhoneValitdation
    {
        public static ValidationResult ValidatePhone(string phone, ValidationContext context)
        {
            if (string.IsNullOrEmpty(phone))
            {
                return new ValidationResult("Phone is required");
            }

            if (phone.Length < 7 || phone.Length > 10)
            {
                return new ValidationResult("The length of the Phone  must be between 7 and 10 characters");
            }

            var regex = new Regex(@"^0\d{6,9}$");
            if (!regex.IsMatch(phone))
            {
                return new ValidationResult("The Phone  must start with 0 and contain only digits");
            }

            return ValidationResult.Success;
        }
    }
}
