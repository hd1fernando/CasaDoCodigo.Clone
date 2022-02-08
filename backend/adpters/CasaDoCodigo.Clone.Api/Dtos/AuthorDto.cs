using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Clone.Api.Dtos;
public class AuthorDto
{
    [Required(ErrorMessage = "{0} is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [EmailAddress(ErrorMessage = "{0} need be a email format")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(400, ErrorMessage = "{0} can't have more than {1} characteres")]
    public string? Description { get; set; }
}