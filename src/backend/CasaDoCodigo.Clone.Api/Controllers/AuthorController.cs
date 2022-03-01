using CasaDoCodigo.Clone.Api.Dtos;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private IAuthorRepository _authorRepository;

    public AuthorController(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    [HttpPost]
    public async Task<ActionResult> Create(AuthorDto authorDto, CancellationToken cancellationToken)
    {
        var author = authorDto.ToModel();

        await _authorRepository.CreateAuthorAsync(author, cancellationToken);

        return Ok();
    }
}
