using CasaDoCodigo.Clone.Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{

    [HttpPost]
    public async Task<ActionResult> Create(AuthorDto authorDto, CancellationToken cancellationToken)
    {
        var author = authorDto.ToModel();
        
        return Ok();
    }
}
