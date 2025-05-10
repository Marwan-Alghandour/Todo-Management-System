using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.CustomValidators
{
    public class NotBeforeTodayDateValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateOnly date && date.CompareTo(DateOnly.FromDateTime(DateTime.Now)) < 0)
            {
                return new ValidationResult(ErrorMessage);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
