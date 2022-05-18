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
    private readonly IRepository<CountryEntity> _countryEntity;
    public PaymentController(INotifier notifier, IRepository<StateEntity> stateEntity, IRepository<CountryEntity> countryEntity) : base(notifier)
    {
        _stateEntity = stateEntity;
        _countryEntity = countryEntity;
    }

    [HttpPost]
    public async Task<ActionResult> Create(PaymentDto paymentDto, CancellationToken cancellation)
    {
        ValidateWithMessage(await _stateEntity.ValueAlreadyExistAsync(s => s.Country.Id == paymentDto.CountryCode) && paymentDto.StateCode == default,
            "Estado é obrigatório");

        var country = await _countryEntity.GetAsync(paymentDto.CountryCode, cancellation);

        StateEntity state = null;
        if (paymentDto.StateCode > 0)
            state = await _stateEntity.GetAsync(paymentDto.StateCode, cancellation);

        var payment = paymentDto.ToModel(country, state);

        return CustomResponse();
    }
}
