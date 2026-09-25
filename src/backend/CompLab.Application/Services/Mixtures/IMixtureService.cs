using CompLab.Application.DTOs.Mixtures;

namespace CompLab.Application.Services.Mixtures;

public interface IMixtureService
{
    Task<List<MixtureDto>> GetAllAsync();

    Task<MixtureDto?> GetByIdAsync(Guid id);

    Task<Guid> CreateAsync(
        string code,
        decimal polymerPercent,
        decimal quartzitePercent);

    Task UpdateAsync(
        Guid id,
        decimal polymerPercent,
        decimal quartzitePercent);

    Task DeleteAsync(Guid id);
}
