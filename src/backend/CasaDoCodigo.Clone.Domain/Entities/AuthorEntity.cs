namespace CasaDoCodigo.Clone.Domain.Entities;

public class AuthorEntity
{
    public int Id { get; }
    public string? Name { get; }
    public string? Description { get; }
    public DateTimeOffset RegistrationTime { get; }

    public int EmailId { get; set; }
    public Email Email { get; }

    public AuthorEntity() { }

    public AuthorEntity(string? name, string? email, string? description)
    {
        PreConditions(name, email, description);

        Name = name;
        Email = email!;
        Description = description;
        RegistrationTime = DateTimeOffset.UtcNow;
    }

    private void PreConditions(string? name, string? email, string? description)
    {
        SelfTesting.IsRequiredWithException(name, nameof(name));
        SelfTesting.IsRequiredWithException(email, nameof(email));
        SelfTesting.IsRequiredWithException(description, nameof(description));

        if (description?.Length > 400)
            throw new ArgumentException($"{nameof(description)} can't have more than 400 characteres.");

    }



}