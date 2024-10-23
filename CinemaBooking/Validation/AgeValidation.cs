using System.ComponentModel.DataAnnotations;

namespace CinemaBooking.Validation
{
    public class AgeValidation
    {
        // Custom validation method to ensure age is at least 18
        public static ValidationResult? ValidateAge(DateTime? dateOfBirth, ValidationContext context)
        {
            if (!dateOfBirth.HasValue)
            {
                return new ValidationResult("Date of Birth is required");
            }

            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Value.Year;

            if (dateOfBirth.Value.Date > today.AddYears(-age)) age--;

            if (age < 18)
            {
                return new ValidationResult("Customer must be at least 18 years old.");
            }

            return ValidationResult.Success;
        }
    }
}
