using CasaDoCodigo.Clone.DatabaseAccess.Context;
using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Clone.DatabaseAccess.Repository;
//CI: 3
// 1
public class CategoryRepository : Repository<CategoryEntity>, ICategoryRepository
{
    // 1
    public CategoryRepository(CasaDoCodigoDbContext context) : base(context) { }

    // 1 
    public async Task<CategoryEntity> GetCategoryByNameAsync(string? name, CancellationToken cancellationToken = default)
        => await DbSet.FirstOrDefaultAsync(c => c.Name == name, cancellationToken);
}
