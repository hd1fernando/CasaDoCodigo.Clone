using CasaDoCodigo.Clone.Api.Dtos.CustomAttributes;
using CasaDoCodigo.Clone.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Clone.Api.Dtos;

public class CartDto
{
    [Required(ErrorMessage = "{0} is required.")]
    [Range(1, double.MaxValue, ErrorMessage = "{0} should be greater than 0.")]
    public decimal Total { get; set; }

    [MinLength(1, ErrorMessage = "At list {1} {0} should exist in the cart")]
    public List<ItemDto> Itens { get; set; }

    public IEnumerable<int> BooksId()
        => Itens.Select(i => i.IdBook);
}

public class ItemDto
{

    [Range(1, int.MaxValue, ErrorMessage = "invalid {0}")]
    public int IdBook { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "{0} shoud be greater than 0.")]
    public int Amount { get; set; }
}

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

    public int StateCode { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    public string? ZipCode { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    public CartDto Cart { get; set; }

    public bool HasStateCode() => StateCode > 0;

    public PaymentEntity ToModel(CountryEntity country, StateEntity state)
        => new PaymentEntity(Email, Name, LastName, FiscalCode, Address, AddressComplement, City, country, state, PhoneNumber, ZipCode);

}
