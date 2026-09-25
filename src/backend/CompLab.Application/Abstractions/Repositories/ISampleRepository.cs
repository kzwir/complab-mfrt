using CompLab.Domain.Entities;

namespace CompLab.Application.Abstractions.Repositories;

public interface ISampleRepository
{
    Task<List<Sample>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Sample?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Sample sample,
        CancellationToken cancellationToken = default);

    void Update(Sample sample);

    void Delete(Sample sample);
}
