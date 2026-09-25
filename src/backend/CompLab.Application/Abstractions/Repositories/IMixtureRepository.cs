using CompLab.Domain.Entities;

namespace CompLab.Application.Abstractions.Repositories;

public interface IMixtureRepository
{
    Task<List<Mixture>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Mixture?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Mixture mixture,
        CancellationToken cancellationToken = default);

    void Update(Mixture mixture);

    void Delete(Mixture mixture);
}
