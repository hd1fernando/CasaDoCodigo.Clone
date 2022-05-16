using CasaDoCodigo.Clone.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Clone.Api.Dtos;

public class CountryDto
{
    [Required(ErrorMessage = "{0} is required.")]
    public string? Name { get; set; }

    public CountryEntity ToModel()
        => new CountryEntity(Name);
}
