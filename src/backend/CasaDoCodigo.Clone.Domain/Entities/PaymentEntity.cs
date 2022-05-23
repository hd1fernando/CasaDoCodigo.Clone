using Jabuticaba;

namespace CasaDoCodigo.Clone.Domain.Entities;

public class PaymentEntity : Entity
{
    public Email Email { get; set; }
    public int EmailId { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? FiscalCode { get; set; }

    public string? Address { get; set; }

    public string? AddressComplement { get; set; }

    public string? City { get; set; }

    public CountryEntity Country { get; set; }

    public StateEntity State { get; set; }

    public string? PhoneNumber { get; set; }

    public string? ZipCode { get; set; }

    [Obsolete("Just for ORM")]
    public PaymentEntity()
    {

    }

    public PaymentEntity(
        string? email,
        string? name,
        string? lastName,
        string? fiscalCode,
        string? address,
        string? addressComplement,
        string? city,
        CountryEntity country,
        string? phoneNumber,
        string? zipCode)
    {
        SelfTesting.IsRequiredWithException(email, nameof(email));
        SelfTesting.IsRequiredWithException(name, nameof(name));
        SelfTesting.IsRequiredWithException(lastName, nameof(lastName));
        SelfTesting.IsRequiredWithException(fiscalCode, nameof(fiscalCode));
        SelfTesting.IsRequiredWithException(address, nameof(address));
        SelfTesting.IsRequiredWithException(addressComplement, nameof(addressComplement));
        SelfTesting.IsRequiredWithException(city, nameof(city));
        SelfTesting.IsRequiredWithException(phoneNumber, nameof(phoneNumber));
        SelfTesting.IsRequiredWithException(zipCode, nameof(zipCode));

        ArgumentNullException.ThrowIfNull(country, nameof(country));
        SelfTesting.Assert(IsValidFiscalCode(fiscalCode) == false, $"{nameof(country)} is invalid.");

        Email = email;
        Name = name;
        LastName = lastName;
        FiscalCode = fiscalCode;
        Address = address;
        AddressComplement = addressComplement;
        City = city;
        Country = country;
        PhoneNumber = phoneNumber;
        ZipCode = zipCode;
    }

    private bool IsValidFiscalCode(string fiscalCode)
    {
        Cpf cpf = fiscalCode;

        if (cpf.EValido)
            return true;

        Cnpj cnpj = fiscalCode;

        return cnpj.EValido;
    }

    public void AddState(StateEntity state)
    {
        ArgumentNullException.ThrowIfNull(Country, nameof(Country));
        SelfTesting.Assert(state.IsInTheCountry(Country) == false, "This state isn't in the country");

        State = state;
    }
}
