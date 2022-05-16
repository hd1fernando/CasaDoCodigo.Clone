using CasaDoCodigo.Clone.Domain.Entities;

namespace CasaDoCodigo.Clone.Domain.Repository;

public interface IBookRepository : IRepository<BookEntity>
{
    public Task<BookEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}
