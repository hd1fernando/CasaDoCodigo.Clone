namespace CasaDoCodigo.Clone.Domain.Entities;

public class BookEntity
{
    public int Id { get; }
    public string? Title { get; }
    public string? Abstract { get; }
    public string? Summary { get; }
    public decimal Price { get; }
    public int NumOfPages { get; }
    public string? ISBN { get; }
    public DateTimeOffset PublicationDate { get; }
    public int CategoryId { get; }
    public int AuthorId { get; }

    public BookEntity() { }

    public BookEntity(string? title, string? @abstract, string? summary, decimal price, int numOfPages, string? isbn, DateTimeOffset publicationDate, int categoryId, int authorId)
    {
        SelfTesting.IsRequiredWithException(title, nameof(title));
        SelfTesting.IsRequiredWithException(@abstract, nameof(@abstract));
        SelfTesting.IsRequiredWithException(isbn, nameof(isbn));

        SelfTesting.Assert(@abstract?.Length <= 500, $"{nameof(@abstract)} can't have more than 500 characteres.");
        SelfTesting.Assert(price >= 20, $"{nameof(price)} can't be less than 20.");
        SelfTesting.Assert(numOfPages <= 100, $"{nameof(numOfPages)} can't be less than 100.");

        Title = title;
        Abstract = @abstract;
        Summary = summary;
        Price = price;
        NumOfPages = numOfPages;
        ISBN = isbn;
        PublicationDate = publicationDate;
        CategoryId = categoryId;
        AuthorId = authorId;
    }
}

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