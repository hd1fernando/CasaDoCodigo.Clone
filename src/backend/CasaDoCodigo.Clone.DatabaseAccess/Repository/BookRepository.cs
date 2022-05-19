using CasaDoCodigo.Clone.DatabaseAccess.Context;
using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Clone.DatabaseAccess.Repository;

public class BookRepository : Repository<BookEntity>, IBookRepository
{
    public BookRepository(CasaDoCodigoDbContext context) : base(context)
    {
    }

    public async Task<BookEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await DbSet
            .Include(a => a.Author)
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

}
