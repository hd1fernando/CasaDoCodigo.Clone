using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Clone.Api.Dtos.CustomAttributes
{
    public class StartDateAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date = (DateTimeOffset?)value;

            if (date < DateTimeOffset.UtcNow)
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
