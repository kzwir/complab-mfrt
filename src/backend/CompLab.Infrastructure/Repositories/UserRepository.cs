using CompLab.Application.Abstractions.Repositories;
using CompLab.Domain.Entities;
using CompLab.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CompLab.Infrastructure.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly CompLabDbContext _dbContext;

    public UserRepository(
        CompLabDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(
                x => x.Email == email,
                cancellationToken);
    }

    public async Task<User?> GetByIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(
                x => x.UserId == userId,
                cancellationToken);
    }
}
