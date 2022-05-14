using System.Linq.Expressions;

namespace CasaDoCodigo.Clone.Domain.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<TEntity> GetAsync(int id, CancellationToken cancellationToken);
    public Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    public Task<bool> ValueAlreadyExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

}
