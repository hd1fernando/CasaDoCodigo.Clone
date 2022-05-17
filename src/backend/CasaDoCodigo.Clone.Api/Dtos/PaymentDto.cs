using CasaDoCodigo.Clone.Api.Dtos.CustomAttributes;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Clone.Api.Dtos;

public class PaymentDto
{
    [Required(ErrorMessage = "{0} is required.")]
    [EmailAddress(ErrorMessage = "{0} should be a valid e-mail")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [FiscalCode(ErrorMessage = "Should be a CPF or CNPJ")]
    public string? FiscalCode { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    public string? Address { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    public string? AddressComplement { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    public string? City { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "{0} is required")]
    public int CountryCode { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "{0} is required")]
    public int StateCode { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    public string? ZipCode { get; set; }

}
