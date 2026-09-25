using CompLab.Application.Abstractions.Repositories;
using CompLab.Application.DTOs.Dashboard;
using CompLab.Application.Mappings;

namespace CompLab.Application.Services.Dashboard;

public sealed class DashboardService : IDashboardService
{
    private readonly IMixtureRepository _mixtureRepository;
    private readonly ISampleRepository _sampleRepository;
    private readonly ITestRepository _testRepository;

    public DashboardService(
        IMixtureRepository mixtureRepository,
        ISampleRepository sampleRepository,
        ITestRepository testRepository)
    {
        _mixtureRepository = mixtureRepository;
        _sampleRepository = sampleRepository;
        _testRepository = testRepository;
    }

    public async Task<DashboardDto> GetAsync()
    {
        var mixtures = await _mixtureRepository.GetAllAsync();
        var samples = await _sampleRepository.GetAllAsync();
        var tests = await _testRepository.GetAllAsync();

        return DashboardMappings.Create(
            mixtures.Count,
            samples.Count,
            tests.Count);
    }
}
