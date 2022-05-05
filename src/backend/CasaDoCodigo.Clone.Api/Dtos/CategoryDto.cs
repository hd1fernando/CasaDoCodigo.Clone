using CasaDoCodigo.Clone.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Clone.Api.Dtos;

// CI: 1
public class CategoryDto
{
    [Required(ErrorMessage = "{0} is required")]
    public string? Name { get; set; }

    // 1
    public CategoryEntity ToModel()
        => new CategoryEntity(Name);
}
