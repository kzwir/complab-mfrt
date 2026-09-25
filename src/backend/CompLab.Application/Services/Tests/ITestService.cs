using CompLab.Application.DTOs.Tests;

namespace CompLab.Application.Services.Tests;

public interface ITestService
{
    Task<List<TestDto>> GetAllAsync();

    Task<TestDto?> GetByIdAsync(Guid id);

    Task<Guid> CreateAsync(
        Guid sampleId,
        string testType,
        decimal measurementValue);

    Task UpdateAsync(
        Guid id,
        decimal measurementValue);

    Task DeleteAsync(Guid id);
}
