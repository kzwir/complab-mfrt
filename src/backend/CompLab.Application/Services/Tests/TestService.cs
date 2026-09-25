using CompLab.Application.Abstractions;
using CompLab.Application.Abstractions.Repositories;
using CompLab.Application.DTOs.Tests;
using CompLab.Application.Mappings;
using CompLab.Domain.Entities;
using CompLab.Domain.Rules;

namespace CompLab.Application.Services.Tests;

public sealed class TestService : ITestService
{
    private readonly ITestRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public TestService(
        ITestRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<TestDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();

        return items
            .Select(x => x.ToDto())
            .ToList();
    }

    public async Task<TestDto?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        return entity?.ToDto();
    }

    public async Task<Guid> CreateAsync(
        Guid sampleId,
        string testType,
        decimal measurementValue)
    {
        TestRules.Validate(
            testType,
            measurementValue);

        var entity = new Test(
            Guid.NewGuid(),
            sampleId,
            testType,
            measurementValue,
            DateTime.UtcNow);

        await _repository.AddAsync(entity);

        await _unitOfWork.SaveChangesAsync();

        return entity.TestId;
    }

    public async Task UpdateAsync(
        Guid id,
        decimal measurementValue)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity is null)
        {
            throw new KeyNotFoundException(
                $"Test '{id}' not found.");
        }

        if (measurementValue <= 0)
        {
            throw new ArgumentException(
                "MeasurementValue must be greater than zero.");
        }

        entity.UpdateMeasurement(measurementValue);

        _repository.Update(entity);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity is null)
        {
            return;
        }

        _repository.Delete(entity);

        await _unitOfWork.SaveChangesAsync();
    }
}
