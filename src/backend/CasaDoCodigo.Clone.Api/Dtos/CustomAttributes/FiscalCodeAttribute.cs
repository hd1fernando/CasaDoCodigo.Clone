using Jabuticaba;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Clone.Api.Dtos.CustomAttributes
{
    public class FiscalCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Cpf cpf = value?.ToString();

            if (cpf.EValido)
                return ValidationResult.Success;

            Cnpj cnpj = value?.ToString();
            if (cnpj.EValido)
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}
