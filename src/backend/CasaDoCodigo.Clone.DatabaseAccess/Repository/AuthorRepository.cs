﻿using CasaDoCodigo.Clone.DatabaseAccess.Context;
using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Clone.DatabaseAccess.Repository;

public class AuthorRepository : IAuthorRepository
{
    public CasaDoCodigoDbContext Context { get; }
    public DbSet<AuthorEntity> DbSet { get; }

    public AuthorRepository(CasaDoCodigoDbContext context)
    {
        Context = context;
        DbSet = context.Set<AuthorEntity>();
    }

    public async Task CreateAuthorAsync(AuthorEntity author, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(author, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task<AuthorEntity> GetAuthorByEmailAsync(Email email, CancellationToken cancellationToken = default)
        => await DbSet.FirstOrDefaultAsync(a => a.Email.Value == email.Value, cancellationToken);
}