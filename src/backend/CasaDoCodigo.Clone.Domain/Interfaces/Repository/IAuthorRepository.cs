using CasaDoCodigo.Clone.Domain.Entities;

namespace CasaDoCodigo.Clone.Domain.Repository;

public interface IAuthorRepository
{
    public Task CreateAuthorAsync(AuthorEntity author, CancellationToken cancellationToken = default);
    public Task<AuthorEntity> GetAuthorByEmailAsync(Email email, CancellationToken cancellationToken = default);
}
