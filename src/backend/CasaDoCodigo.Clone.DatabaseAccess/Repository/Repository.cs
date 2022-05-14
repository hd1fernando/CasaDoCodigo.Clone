using CasaDoCodigo.Clone.DatabaseAccess.Context;
using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CasaDoCodigo.Clone.DatabaseAccess.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
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

    public async Task<bool> ValueAlreadyExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => await DbSet.FirstOrDefaultAsync(predicate, cancellationToken) is not null;

    public async Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default)
        => await DbSet.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
}
