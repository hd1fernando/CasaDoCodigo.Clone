using CasaDoCodigo.Clone.Domain.Entities;

namespace CasaDoCodigo.Clone.Domain.Interfaces.Service;

public interface ICategoryService
{
    public Task CreateCategoryAsync(CategoryEntity category, CancellationToken cancellationToken = default);
}
