using CasaDoCodigo.Clone.Api.Dtos;
using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

//CI:9
[Route("api/[controller]")]
// 1
public class StateController : MainController
{

    private readonly IRepository<CountryEntity> _countryRepository;
    private readonly IRepository<StateEntity> _stateRepository;

    // 4
    public StateController(INotifier notifier, IRepository<CountryEntity> countryRepository, IRepository<StateEntity> stateRepository) : base(notifier)
    {
        _countryRepository = countryRepository;
        _stateRepository = stateRepository;
    }

    [HttpPost]
    // 1
    public async Task<ActionResult> Create(StateDto stateDto, CancellationToken cancellationToken)
    {
        var country = await _countryRepository.GetAsync(stateDto.CountryCode, cancellationToken);

        ValidateWithMessage(country is null, "O Pais não existe");
        // 1
        if (HasErrorMessage())
            return CustomResponse();

        ValidateWithMessage(
            // 1
            await _stateRepository.ValueAlreadyExistAsync(c => c.Name == stateDto.Name && c.Country.Id == stateDto.CountryCode),
            "Esse estádo já está cadastrado para o pais informado");

        // 1
        if (HasErrorMessage())
            return CustomResponse();

        var state = stateDto.ToModel(country);

        await _stateRepository.CreateAsync(state, cancellationToken);

        return CustomResponse();
    }
}
