﻿using CasaDoCodigo.Clone.Domain.Entities;
using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Interfaces.Service;
using CasaDoCodigo.Clone.Domain.Repository;

namespace CasaDoCodigo.Clone.Domain.Service;
public class AuthorService : BaseService, IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(INotifier notifier, IAuthorRepository authorRepository) : base(notifier)
    {
        _authorRepository = authorRepository;
    }

    public async Task CreateAuthorAsync(AuthorEntity author, CancellationToken cancellationToken = default)
    {
        if (await _authorRepository.ValueAlreadyExistAsync(e => e.Email.Value == author.Email.Value, cancellationToken))
        {
            SendNotification("Email já cadastrado");
            return;
        }

        await _authorRepository.CreateAuthorAsync(author, cancellationToken);
    }
}
