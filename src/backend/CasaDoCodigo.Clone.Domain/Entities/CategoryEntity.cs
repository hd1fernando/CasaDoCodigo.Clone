namespace CasaDoCodigo.Clone.Domain.Entities;

public class CategoryEntity : Entity
{
    public string? Name { get; }
    public ICollection<BookEntity> Books { get; }

    public CategoryEntity(string? name)
    {
        PreConditions(name);
        Name = name;
    }

    public CategoryEntity() { }

    private void PreConditions(string? name)
    {
        SelfTesting.IsRequiredWithException(name, nameof(name));
    }
}
