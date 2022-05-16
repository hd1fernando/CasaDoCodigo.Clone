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
            .FirstOrDefaultAsync(a => a.Id == id,cancellationToken);

}

// CI: 4
// 1
public class AuthorRepository : Repository<AuthorEntity>, IAuthorRepository
{
    // 2
    public AuthorRepository(CasaDoCodigoDbContext context) : base(context)
    {
    }

    public async Task CreateAuthorAsync(AuthorEntity author, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(author, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
    }

    // 1
    public async Task<AuthorEntity> GetAuthorByEmailAsync(Email email, CancellationToken cancellationToken = default)
        => await DbSet.FirstOrDefaultAsync(a => a.Email.Value == email.Value, cancellationToken);
}