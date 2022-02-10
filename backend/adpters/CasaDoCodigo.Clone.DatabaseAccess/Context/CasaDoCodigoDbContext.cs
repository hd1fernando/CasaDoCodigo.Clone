using CasaDoCodigo.Clone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Clone.DatabaseAccess.Context;
public class CasaDoCodigoDbContext : DbContext
{
    public CasaDoCodigoDbContext(DbContextOptions<CasaDoCodigoDbContext> options) : base(options)
    { }


    public DbSet<AuthorEntity> Authors { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(CasaDoCodigoDbContext).Assembly);
        base.OnModelCreating(builder);
    }
}