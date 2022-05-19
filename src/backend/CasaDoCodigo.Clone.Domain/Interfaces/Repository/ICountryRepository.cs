using CasaDoCodigo.Clone.Domain.Entities;

namespace CasaDoCodigo.Clone.Domain.Repository;

public interface ICountryRepository : IRepository<CountryEntity>
{
    public Task<CountryEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
}
