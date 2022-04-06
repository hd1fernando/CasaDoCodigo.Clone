using CasaDoCodigo.Clone.DatabaseAccess.Context;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Clone.DatabaseAccess.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    public CasaDoCodigoDbContext Context { get; }
    public DbSet<TEntity> DbSet { get; }

    public Repository(CasaDoCodigoDbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }


    public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
    }
}
