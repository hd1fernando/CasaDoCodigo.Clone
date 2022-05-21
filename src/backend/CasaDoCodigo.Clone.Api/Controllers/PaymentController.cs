using CasaDoCodigo.Clone.Api.Dtos;
using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

// CI: 8
[Route("api/[controller]")]
public class PaymentController : MainController
{
    private readonly IStateRepository _stateRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IBookRepository _bookRepository;
    //3
    public PaymentController(INotifier notifier, ICountryRepository countryRepository, IStateRepository stateRepository, IBookRepository bookRepository) : base(notifier)
    {
        _countryRepository = countryRepository;
        _stateRepository = stateRepository;
        _bookRepository = bookRepository;
    }

    [HttpPost]
    // 1
    public async Task<ActionResult> Create(PaymentDto paymentDto, CancellationToken cancellation)
    {
        var country = await _countryRepository.GetByIdAsync(paymentDto.CountryCode, cancellation);

        ValidateWithMessage(country is null, "O país informado não existe");
        if (HasErrorMessage())
            return CustomResponse();

        ValidateWithMessage(country.HasState() && paymentDto.HasStateCode() == false, "Um estado deve ser selecionado");
        // 1
        if (HasErrorMessage())
            return CustomResponse();

        // 1
        StateEntity state = null;
        if (paymentDto.HasStateCode())
        {
            state = await _stateRepository.GetByIdAsync(paymentDto.StateCode, cancellation);
            ValidateWithMessage(state is null, "O estado informado não existe");
            ValidateWithMessage(state.IsInTheCountry(country) == false, "O estado informado não pertence a esse pais");

            // 1
            if (HasErrorMessage())
                return CustomResponse();
        }

        var itens = paymentDto.Cart.Itens;
        var calculatedAmount = 0m;

        foreach (var iten in itens)
        {
            var bookId = iten.IdBook;
            var book = await _bookRepository.GetAsync(bookId, cancellation);
            ValidateWithMessage(book is null, $"O livro informado com o id {bookId} não existe.");
            calculatedAmount += book.Price * iten.Amount;
        }

        ValidateWithMessage(calculatedAmount != paymentDto.Cart.Total, $"O total envido é inválido. O total deveria ser {calculatedAmount}");

        var payment = paymentDto.ToModel(country, state);

        return CustomResponse();
    }
}
