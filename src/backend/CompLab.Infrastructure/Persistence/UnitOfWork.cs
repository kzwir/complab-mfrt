using CompLab.Application.Abstractions;

namespace CompLab.Infrastructure.Persistence;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly CompLabDbContext _dbContext;

    public UnitOfWork(
        CompLabDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(
            cancellationToken);
    }
}
``
