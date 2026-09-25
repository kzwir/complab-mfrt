using CompLab.Domain.Entities;

namespace CompLab.Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken = default);

    Task<User?> GetByIdAsync(
        Guid userId,
        CancellationToken cancellationToken = default);
}
