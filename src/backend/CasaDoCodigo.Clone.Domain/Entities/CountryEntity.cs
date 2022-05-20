namespace CasaDoCodigo.Clone.Domain.Entities;

public class CountryEntity : Entity
{
    public string? Name { get; }
    public CountryEntity() { }
    public ICollection<StateEntity> States { get; }

    public CountryEntity(string? name)
    {
        SelfTesting.Assert(string.IsNullOrEmpty(name), $"{nameof(name)} is required");

        Name = name;
    }

    public bool HasState()
        => States != null && States.Any();

    public override bool Equals(object obj)
    {
        if (this == obj)
            return true;
        if (obj is null)
            return false;
        var country = (CountryEntity)obj;
        if (Name is null)
        {
            if (country.Name is not null)
                return false;
        }
        else if (!Name.Equals(country.Name))
            return false;

        return true;
    }
}
