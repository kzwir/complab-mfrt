using CompLab.Application.Abstractions;
using CompLab.Application.Abstractions.Repositories;
using CompLab.Application.DTOs.Mixtures;
using CompLab.Application.Mappings;
using CompLab.Domain.Entities;
using CompLab.Domain.Rules;

namespace CompLab.Application.Services.Mixtures;

public sealed class MixtureService : IMixtureService
{
    private readonly IMixtureRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public MixtureService(
        IMixtureRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<MixtureDto>> GetAllAsync()
    {
        var items = await _repository.GetAllAsync();

        return items
            .Select(x => x.ToDto())
            .ToList();
    }

    public async Task<MixtureDto?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        return entity?.ToDto();
    }

    public async Task<Guid> CreateAsync(
        string code,
        decimal polymerPercent,
        decimal quartzitePercent)
    {
        MixtureRules.ValidateComposition(
            polymerPercent,
            quartzitePercent);

        var entity = new Mixture(
            Guid.NewGuid(),
            code,
            polymerPercent,
            quartzitePercent);

        await _repository.AddAsync(entity);

        await _unitOfWork.SaveChangesAsync();

        return entity.MixtureId;
    }

    public async Task UpdateAsync(
        Guid id,
        decimal polymerPercent,
        decimal quartzitePercent)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity is null)
        {
            throw new KeyNotFoundException(
                $"Mixture '{id}' not found.");
        }

        MixtureRules.ValidateComposition(
            polymerPercent,
            quartzitePercent);

        entity.UpdateComposition(
            polymerPercent,
            quartzitePercent);

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
