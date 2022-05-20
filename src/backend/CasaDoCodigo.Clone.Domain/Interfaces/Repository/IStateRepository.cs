using CasaDoCodigo.Clone.Domain.Entities;

namespace CasaDoCodigo.Clone.Domain.Repository;

public interface IStateRepository : IRepository<StateEntity>
{
    public Task<StateEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}
