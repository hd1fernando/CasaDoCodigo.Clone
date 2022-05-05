using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Interfaces.Service;
using CasaDoCodigo.Clone.Domain.Repository;

namespace CasaDoCodigo.Clone.Domain.Service;

// CI: 4
public class CategoryService : BaseService, ICategoryService
{
    // 1
    private readonly ICategoryRepository _categoryRepository;

    // 1
    public CategoryService(INotifier notifier, ICategoryRepository categoryRepository) : base(notifier)
    {
        _categoryRepository = categoryRepository;
    }

    // 1
    public async Task CreateCategoryAsync(CategoryEntity category, CancellationToken cancellationToken = default)
    {
        // 1
        if (await IsCategoryAlreadyAddedAsync(category))
        {
            SendNotification("Categoria já cadastrada");
            return;
        }

        await _categoryRepository.CreateAsync(category, cancellationToken);
    }

    public async Task<bool> IsCategoryAlreadyAddedAsync(CategoryEntity categoryEntity)
        => await _categoryRepository.GetCategoryByNameAsync(categoryEntity.Name) is not null;
}
