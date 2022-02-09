namespace CasaDoCodigo.Clone.Domain.Entities;

public class Author
{
    public int Id { get; }
    public string? Name { get; }
    public Email Email { get; }
    public string? Description { get; }
    public DateTimeOffset RegistrationTime { get; }

    public Author(string? name, string? email, string? description)
    {
        PreConditions(name, email, description);
        
        Name = name;
        Email = email!;
        Description = description;
        RegistrationTime = DateTimeOffset.UtcNow;
    }

    private void PreConditions(string? name, string? email, string? description)
    {
        IsRequiredWithException(name, nameof(name));
        IsRequiredWithException(email, nameof(email));
        IsRequiredWithException(description, nameof(description));

        if (description?.Length > 400)
            throw new ArgumentException($"{nameof(description)} can't have more than 400 characteres.");

    }

    private void IsRequiredWithException(string? value, string propName)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException($"{propName} is required.");
    }

}