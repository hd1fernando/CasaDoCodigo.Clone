using CasaDoCodigo.Clone.DatabaseAccess.Context;
using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Clone.DatabaseAccess.Repository;

public class CountryRepository : Repository<CountryEntity>, ICountryRepository
{
    public CountryRepository(CasaDoCodigoDbContext context) : base(context)
    {
    }

    public async Task<CountryEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await DbSet
            .Include(a => a.States)
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
}
