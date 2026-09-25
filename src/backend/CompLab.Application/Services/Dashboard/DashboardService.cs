using CompLab.Application.Abstractions.Repositories;
using CompLab.Application.DTOs.Dashboard;

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

    public
