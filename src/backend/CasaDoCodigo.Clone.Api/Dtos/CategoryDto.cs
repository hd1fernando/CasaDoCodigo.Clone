using CasaDoCodigo.Clone.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Clone.Api.Dtos;

public class CategoryDto
{
    [Required(ErrorMessage = "{0} is required")]
    public string? Name { get; set; }

    public CategoryEntity ToModel()
        => new CategoryEntity(Name);

}
