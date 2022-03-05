using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Interfaces.Service;
using CasaDoCodigo.Clone.Domain.Repository;

namespace CasaDoCodigo.Clone.Domain.Service;

public class AuthorService : BaseService, IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(INotifier notifier, IAuthorRepository authorRepository) : base(notifier)
    {
        _authorRepository = authorRepository;
    }

    public async Task CreateAuthorAsync(AuthorEntity author, CancellationToken cancellationToken = default)
    {
        if (await IsEmailAlreadyAddedAsync(author.Email, cancellationToken))
        {
            SendNotification("Email já cadastrado");
            return;
        }

        await _authorRepository.CreateAuthorAsync(author, cancellationToken);
    }

    private async Task<bool> IsEmailAlreadyAddedAsync(Email email, CancellationToken cancellationToken)
        => await _authorRepository.GetAuthorByEmailAsync(email, cancellationToken) is null;
}
