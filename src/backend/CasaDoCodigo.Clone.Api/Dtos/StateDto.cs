using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Clone.Api.Dtos;

public class StateDto
{
    [Required(ErrorMessage = "{0} is required.")]
    public string? Name { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "{0} is required.")]
    public int CountryCode { get; set; }
}
