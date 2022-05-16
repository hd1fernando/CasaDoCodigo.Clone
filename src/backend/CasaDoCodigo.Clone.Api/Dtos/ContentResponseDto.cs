using CasaDoCodigo.Clone.Domain.Entities;

namespace CasaDoCodigo.Clone.Api.Dtos;

public class ContentResponseDto
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Summary { get; set; }
    public string? AuthorName { get; set; }
    public string? AuthorDescription { get; set; }
    public int NumberOfpages { get; set; }
    public string? ISBN { get; set; }
    public DateTimeOffset PublicationDate { get; set; }

    public ContentResponseDto(BookEntity bookEntity)
    {
        Title = bookEntity.Title;
        Content = bookEntity.Abstract;
        Summary = bookEntity.Summary;
        AuthorName = bookEntity.Author.Name;
        AuthorDescription = bookEntity.Author.Description;
        NumberOfpages = bookEntity.NumOfPages;
        ISBN = bookEntity.ISBN;
        PublicationDate = bookEntity.PublicationDate;
    }
}
