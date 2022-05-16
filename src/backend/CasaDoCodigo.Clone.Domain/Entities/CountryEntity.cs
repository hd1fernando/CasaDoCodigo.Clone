namespace CasaDoCodigo.Clone.Domain.Entities;

public class CountryEntity : Entity
{
    public string? Name { get; }
    public CountryEntity() { }

    public CountryEntity(string? name)
    {
        SelfTesting.Assert(string.IsNullOrEmpty(name), $"{nameof(name)} is required");

        Name = name;
    }
}
