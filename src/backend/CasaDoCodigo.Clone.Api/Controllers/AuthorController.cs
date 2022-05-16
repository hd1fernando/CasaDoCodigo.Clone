using CasaDoCodigo.Clone.Api.Dtos;
using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

[Route("api/[controller]")]
public class AuthorController : MainController
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService, INotifier notifier) : base(notifier)
    {
        _authorService = authorService;
    }

    [HttpPost]
    public async Task<ActionResult> Create(AuthorDto authorDto, CancellationToken cancellationToken)
    {
        var author = authorDto.ToModel();

        await _authorService.CreateAuthorAsync(author, cancellationToken);

        return CustomResponse();
    }
}
