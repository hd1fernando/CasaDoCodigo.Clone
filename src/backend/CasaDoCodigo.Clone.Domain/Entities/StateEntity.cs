namespace CasaDoCodigo.Clone.Domain.Entities;

public class StateEntity : Entity
{
    public string? Name { get; }
    public CountryEntity? Country { get; }
    public ICollection<PaymentEntity> Purposes { get; }

    public StateEntity() { }

    public StateEntity(string? name, CountryEntity? country)
    {
        SelfTesting.Assert(string.IsNullOrEmpty(name), $"{nameof(name)} is required.");
        SelfTesting.Assert(country is null, $"{nameof(country)} is required");

        Name = name;
        Country = country;
    }

    public bool IsInTheCountry(CountryEntity country)
        => country.Id == Country.Id;
}
