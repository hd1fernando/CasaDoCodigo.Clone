namespace CasaDoCodigo.Clone.Domain.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    public Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
}
