using System.ComponentModel.DataAnnotations;

namespace Movies_API.Controllers
{

    public class CurrentYearAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int year = (int)value;
            int currentYear = DateTime.Now.Year;

            if (year >= 1800 && year <= currentYear)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"O ano deve estar entre 1800 e {currentYear}.");
        }
    }
}
