using CasaDoCodigo.Clone.Api.Dtos;
using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

// CI: 7
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
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    // 1
    public async Task<ActionResult> CreateBook(BookDto bookDto, CancellationToken cancellationToken)
    {
        var categoryEntity = await _categoryRepository.GetAsync(bookDto.CategoryId, cancellationToken);
        ValidateWithMessage(categoryEntity is null, "A categoria não exite.");

        var authorEntity = await _authorRepository.GetAsync(bookDto.AuthorId, cancellationToken);
        ValidateWithMessage(authorEntity is null, "Autor inexistente.");

        ValidateWithMessage(
            await _bookRepository.ValueAlreadyExistAsync(b => b.ISBN == bookDto.ISBN, cancellationToken),
            "ISBN já cadastrado");

        ValidateWithMessage(
            await _bookRepository.ValueAlreadyExistAsync(b => b.Title == bookDto.Title, cancellationToken),
            "Título já cadastrado.");

        // 1
        if (HasErrorMessage())
            return CustomResponse();

        var bookEntity = bookDto.ToModel(categoryEntity, authorEntity);

        await _bookRepository.CreateAsync(bookEntity, cancellationToken);

        return CustomResponse();
    }

}
