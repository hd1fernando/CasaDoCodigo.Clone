using CasaDoCodigo.Clone.Domain.Entities;

namespace CasaDoCodigo.Clone.Domain.Repository;

// CI: 2
public interface IAuthorRepository : IRepository<AuthorEntity>
{
    public Task CreateAuthorAsync(AuthorEntity author, CancellationToken cancellationToken = default);
    public Task<AuthorEntity> GetAuthorByEmailAsync(Email email, CancellationToken cancellationToken = default);
}
