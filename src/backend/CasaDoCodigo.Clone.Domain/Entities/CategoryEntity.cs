namespace CasaDoCodigo.Clone.Domain.Entities;

public class CategoryEntity
{
    public int Id { get; }
    public string? Name { get; }

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
