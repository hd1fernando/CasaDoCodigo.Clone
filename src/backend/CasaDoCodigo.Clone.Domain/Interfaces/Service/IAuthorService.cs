using CasaDoCodigo.Clone.Domain.Entities;

namespace CasaDoCodigo.Clone.Domain.Interfaces.Service;
public interface IAuthorService
{
    public Task CreateAuthorAsync(AuthorEntity author, CancellationToken cancellation);
}
