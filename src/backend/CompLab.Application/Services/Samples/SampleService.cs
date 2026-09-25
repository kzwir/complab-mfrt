using CompLab.Application.Abstractions;
using CompLab.Application.Abstractions.Repositories;
using CompLab.Application.DTOs.Samples;
using CompLab.Application.Mappings;
using CompLab.Domain.Entities;
using CompLab.Domain.Rules;

namespace CompLab.Application.Services.Samples;

public sealed class SampleService : ISampleService
{
    private readonly ISampleRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public SampleService(
        ISampleRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<SampleDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();

        return items
            .Select(x => x.ToDto())
            .ToList();
    }

    public async Task<SampleDto?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        return entity?.ToDto();
    }

    public async Task<Guid> CreateAsync(
        Guid mixtureId,
        string sampleNumber,
        DateOnly productionDate)
    {
        SampleRules.Validate(sampleNumber);

        var entity = new Sample(
            Guid.NewGuid(),
            mixtureId,
            sampleNumber,
            productionDate);

        await _repository.AddAsync(entity);

        await _unitOfWork.SaveChangesAsync();

        return entity.SampleId;
    }

    public async Task UpdateAsync(
        Guid id,
        string sampleNumber)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity is null)
        {
            throw new KeyNotFoundException(
                $"Sample '{id}' not found.");
        }

        SampleRules.Validate(sampleNumber);

        entity.UpdateSampleNumber(sampleNumber);

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
