using CompLab.Application.Abstractions.Repositories;
using CompLab.Domain.Entities;
using CompLab.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CompLab.Infrastructure.Repositories;

public sealed class MixtureRepository : IMixtureRepository
{
    private readonly CompLabDbContext _dbContext;

    public MixtureRepository(
        CompLabDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Mixture>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Mixtures.ToListAsync(
            cancellationToken);
    }

    public async Task<Mixture?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Mixtures
            .FirstOrDefaultAsync(
                x => x.MixtureId == id,
                cancellationToken);
    }

    public async Task AddAsync(
        Mixture mixture,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Mixtures.AddAsync(
            mixture,
            cancellationToken);
    }

    public void Update(Mixture mixture)
    {
        _dbContext.Mixtures.Update(mixture);
    }

    public void Delete(Mixture mixture)
    {
        _dbContext.Mixtures.Remove(mixture);
    }
}
