using CompLab.Application.Abstractions.Repositories;
using CompLab.Domain.Entities;
using CompLab.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CompLab.Infrastructure.Repositories;

public sealed class SampleRepository : ISampleRepository
{
    private readonly CompLabDbContext _dbContext;

    public SampleRepository(
        CompLabDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Sample>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Samples.ToListAsync(
            cancellationToken);
    }

    public async Task<Sample?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Samples
            .FirstOrDefaultAsync(
                x => x.SampleId == id,
                cancellationToken);
    }

    public async Task AddAsync(
        Sample sample,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Samples.AddAsync(
            sample,
            cancellationToken);
    }

    public void Update(Sample sample)
    {
        _dbContext.Samples.Update(sample);
    }

    public void Delete(Sample sample)
    {
        _dbContext.Samples.Remove(sample);
    }
}
