using CasaDoCodigo.Clone.Api.Dtos;
using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

[Route("api/[controller]")]
public class DetailsController : MainController
{
    private readonly IBookRepository _bookRepository;

    public DetailsController(IBookRepository bookRepository, INotifier notifier):base(notifier)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ContentResponseDto>> Details(int id, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(id, cancellationToken);

        ValidateWithMessage(book is null, "Livro inexistente");
        if (HasErrorMessage())
            return CustomResponse();

        var contentResponse = new ContentResponseDto(book);

        return CustomResponse(contentResponse);
    }
}
