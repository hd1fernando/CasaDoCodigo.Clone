using CasaDoCodigo.Clone.Api.Dtos;
using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

[Route("api/[controller]")]
// CI: 5
public class ListBookController : MainController
{
    private readonly IRepository<BookEntity> _bookRepository;
    //3
    public ListBookController(INotifier notifier, IRepository<BookEntity> bookRepository) : base(notifier)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    // 1
    public async Task<ActionResult<IEnumerable<BookDtoRespose>>> GetAllBooks(CancellationToken cancellation)
    {
        var books = await _bookRepository.GetAllAsync(cancellation);
        // 1 (lambda)
        var response = books.Select(b => new BookDtoRespose(b.Id, b.Title));

        return CustomResponse(response);
    }
}
