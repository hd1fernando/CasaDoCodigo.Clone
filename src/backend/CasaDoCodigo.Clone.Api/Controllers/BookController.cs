using CasaDoCodigo.Clone.Api.Dtos;
using CasaDoCodigo.Clone.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

[Route("api/[controller]")]
public class BookController : MainController
{
    public BookController(INotifier notifier) : base(notifier)
    {
    }

    [HttpPost]
    public ActionResult CreateBook(BookDto bookDto)
    {

        return CustomResponse();
    }
}
