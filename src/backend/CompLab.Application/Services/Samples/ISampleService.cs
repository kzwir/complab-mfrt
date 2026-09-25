using CompLab.Application.DTOs.Samples;

namespace CompLab.Application.Services.Samples;

public interface ISampleService
{
    Task<List<SampleDto>> GetAllAsync();

    Task<SampleDto?> GetByIdAsync(Guid id);

    Task<Guid> CreateAsync(
        Guid mixtureId,
        string sampleNumber,
        DateOnly productionDate);

    Task UpdateAsync(
        Guid id,
        string sampleNumber);

    Task DeleteAsync(Guid id);
}
