using CompLab.Domain.Entities;

namespace CompLab.Application.Abstractions.Repositories;

public interface ITestRepository
{
    Task<List<Test>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Test?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Test test,
        CancellationToken cancellationToken = default);

    void Update(Test test);

    void Delete(Test test);
}
