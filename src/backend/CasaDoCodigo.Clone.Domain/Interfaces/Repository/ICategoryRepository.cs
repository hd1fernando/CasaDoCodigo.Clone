using CasaDoCodigo.Clone.Domain.Entities;

namespace CasaDoCodigo.Clone.Domain.Repository;

public interface ICategoryRepository : IRepository<CategoryEntity>
{
    public Task<CategoryEntity> GetCategoryByNameAsync(string? name, CancellationToken cancellationToken = default);
}
