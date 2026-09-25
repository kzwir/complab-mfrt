using CompLab.Application.Abstractions.Repositories;
using CompLab.Domain.Entities;
using CompLab.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CompLab.Infrastructure.Repositories;

public sealed class TestRepository : ITestRepository
{
    private readonly CompLabDbContext _dbContext;

    public TestRepository(
        CompLabDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Test>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Tests.ToListAsync(
            cancellationToken);
    }

    public async Task<Test?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Tests
            .FirstOrDefaultAsync(
                x => x.TestId == id,
                cancellationToken);
    }

    public async Task AddAsync(
        Test test,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Tests.AddAsync(
            test,
            cancellationToken);
    }

    public void Update(Test test)
    {
        _dbContext.Tests.Update(test);
    }

    public void Delete(Test test)
    {
        _dbContext.Tests.Remove(test);
    }
}
