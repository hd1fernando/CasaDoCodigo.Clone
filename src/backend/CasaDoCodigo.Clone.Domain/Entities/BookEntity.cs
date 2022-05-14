namespace CasaDoCodigo.Clone.Domain.Entities;

// CI: 3
public class BookEntity : Entity
{
    public string? Title { get; }
    public string? Abstract { get; }
    public string? Summary { get; }
    public decimal Price { get; }
    public int NumOfPages { get; }
    public string? ISBN { get; }
    public DateTimeOffset PublicationDate { get; }
    // 1
    public CategoryEntity Category { get; }
    // 1
    public AuthorEntity Author { get; }

    public BookEntity() { }

    public BookEntity(string? title, string? @abstract, string? summary, decimal price, int numOfPages, string? isbn, DateTimeOffset publicationDate, CategoryEntity category, AuthorEntity author)
    {
        ArgumentNullException.ThrowIfNull(category, nameof(category));
        ArgumentNullException.ThrowIfNull(author, nameof(author));

        // 1
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
        Author = author;
        Category = category;
    }
}
