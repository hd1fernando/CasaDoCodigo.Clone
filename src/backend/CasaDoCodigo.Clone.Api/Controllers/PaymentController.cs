using CasaDoCodigo.Clone.Api.Dtos;
using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

[Route("api/[controller]")]
public class PaymentController : MainController
{
    private readonly IRepository<StateEntity> _stateEntity;
    private readonly ICountryRepository _countryRepository;
    public PaymentController(INotifier notifier, IRepository<StateEntity> stateEntity, ICountryRepository countryRepository) : base(notifier)
    {
        _stateEntity = stateEntity;
        _countryRepository = countryRepository;
    }

    [HttpPost]
    public async Task<ActionResult> Create(PaymentDto paymentDto, CancellationToken cancellation)
    {
        var country = await _countryRepository.GetByIdAsync(paymentDto.CountryCode, cancellation);

        ValidateWithMessage(country.States is not null && country.States.Any() && paymentDto.HasStateCode() == false, "Um estado deve se selecionado");
        if (HasErrorMessage())
            return CustomResponse();

        StateEntity state = null;
        if (paymentDto.HasStateCode())
        {
            state = await _stateEntity.GetAsync(paymentDto.StateCode, cancellation);
            ValidateWithMessage(state is null, "O estado informado não existe");
            if (HasErrorMessage())
                return CustomResponse();
        }

        var payment = paymentDto.ToModel(country, state);

        return CustomResponse();
    }
}
