using CasaDoCodigo.Clone.Domain.Entities;

namespace CasaDoCodigo.Clone.Api.Dtos;

public class BookDtoRespose
{
    public BookDtoRespose(int id, string? title)
    {
        Id = id;
        Title = title;
    }

    public int Id { get; set; }
    public string? Title { get; set; }

}
