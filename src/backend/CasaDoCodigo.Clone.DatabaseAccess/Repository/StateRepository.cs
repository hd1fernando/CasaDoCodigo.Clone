using CasaDoCodigo.Clone.DatabaseAccess.Context;
using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Clone.DatabaseAccess.Repository;

public class StateRepository : Repository<StateEntity>, IStateRepository
{
    public StateRepository(CasaDoCodigoDbContext context) : base(context)
    {
    }

    public async Task<StateEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await DbSet.Include(s => s.Country)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
}
