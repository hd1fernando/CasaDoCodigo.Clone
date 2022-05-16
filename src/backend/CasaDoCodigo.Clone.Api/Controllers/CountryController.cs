using CasaDoCodigo.Clone.Api.Dtos;
using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

[Route("api/[controller]")]
public class CountryController : MainController
{
    private readonly IRepository<CountryEntity> _countryRepository;

    public CountryController(INotifier notifier, IRepository<CountryEntity> countryRepository) : base(notifier)
    {
        _countryRepository = countryRepository;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CountryDto countryDto, CancellationToken cancellationToken)
    {
        var country = countryDto.ToModel();

        ValidateWithMessage(
            await _countryRepository.ValueAlreadyExistAsync(c => c.Name == countryDto.Name, cancellationToken),
            "País já cadastrado");

        if (HasErrorMessage())
            return CustomResponse();

        await _countryRepository.CreateAsync(country, cancellationToken);

        return CustomResponse();
    }
}
