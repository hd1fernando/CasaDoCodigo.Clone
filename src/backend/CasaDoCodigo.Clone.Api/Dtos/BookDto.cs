using CasaDoCodigo.Clone.Api.Dtos.CustomAttributes;
using CasaDoCodigo.Clone.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Clone.Api.Dtos;

public class BookDto
{
    [Required(ErrorMessage = "{0} is required.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    [MaxLength(500, ErrorMessage = "{0} can't have more than {1} characteres.")]
    public string? Abstract { get; set; }

    public string? Summary { get; set; }

    [Range(20, double.MaxValue, ErrorMessage = "{0} can't be less than {1}.")]
    public decimal Price { get; set; }

    [Range(100, int.MaxValue, ErrorMessage = "{0} can't be less than {1}.")]
    public int NumOfPages { get; set; }

    [Required(ErrorMessage = "{0} is required.")]
    public string? ISBN { get; set; }

    [StartDate(ErrorMessage = "PublicationDate should be now or in the future.")]
    public DateTimeOffset PublicationDate { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "{0} is required.")]
    public int CategoryId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "{0} is required.")]
    public int AuthorId { get; set; }


    public BookEntity ToModel(CategoryEntity category, AuthorEntity author)
        => new BookEntity(Title, Abstract, Summary, Price, NumOfPages, ISBN, PublicationDate, category, author);
}
