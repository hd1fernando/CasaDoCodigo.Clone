using CasaDoCodigo.Clone.Api.Dtos;
using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

// CI: 9
[Route("api/[controller]")]
public class BookController : MainController
{
    private IRepository<CategoryEntity> _categoryRepository;
    private IRepository<BookEntity> _bookRepository;
    private IRepository<AuthorEntity> _authorRepository;

    // 5
    public BookController(
        IRepository<CategoryEntity> categoryRepository,
        IRepository<BookEntity> bookRepository,
        IRepository<AuthorEntity> authorRepository,
        INotifier notifier) : base(notifier)
    {
        _categoryRepository = categoryRepository;
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }

    [HttpPost]
    // 1
    public async Task<ActionResult> CreateBook(BookDto bookDto, CancellationToken cancellationToken)
    {
        var categoryEntity = await _categoryRepository.GetAsync(bookDto.CategoryId, cancellationToken);
        // 1
        if (categoryEntity is null)
            return CustomResponse("Non existent category.");

        var authorEntity = await _authorRepository.GetAsync(bookDto.AuthorId, cancellationToken);
        // 1
        if (authorEntity is null)
            return CustomResponse("Non existent author.");

        // 1
        if (await _bookRepository.ValueAlreadyExistAsync(b => b.ISBN == bookDto.ISBN, cancellationToken))
            return CustomResponse("ISBN already exist in the system.");

        var bookEntity = bookDto.ToModel(categoryEntity, authorEntity);

        await _bookRepository.CreateAsync(bookEntity, cancellationToken);

        return CustomResponse();
    }
}
