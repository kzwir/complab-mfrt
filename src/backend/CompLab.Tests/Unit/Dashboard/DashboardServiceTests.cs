using CompLab.Application.Services.Dashboard;
using CompLab.Domain.Entities;
using CompLab.Tests.Fixtures;

namespace CompLab.Tests.Unit.Dashboard;

public sealed class DashboardServiceTests
{
    [Fact]
    public async Task GetAsync_ShouldReturnCounters()
    {
        var fixture = new ServiceFixture();

        fixture.MixtureRepository
            .Setup(x => x.GetAllAsync(default))
            .ReturnsAsync(
            [
                new Mixture(
                    Guid.NewGuid(),
                    "MIX-001",
                    50,
                    50)
            ]);

        fixture.SampleRepository
            .Setup(x => x.GetAllAsync(default))
            .ReturnsAsync(
            [
                new Sample(
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    "SMP-001",
                    DateOnly.FromDateTime(DateTime.Today))
            ]);

        fixture.TestRepository
            .Setup(x => x.GetAllAsync(default))
            .ReturnsAsync(
            [
                new Test(
                    Guid.NewGuid(),
                    Guid.NewGuid(),
                    "MFR",
                    10,
                    DateTime.UtcNow)
            ]);

        var service = new DashboardService(
            fixture.MixtureRepository.Object,
            fixture.SampleRepository.Object,
            fixture.TestRepository.Object);

        var result = await service.GetAsync();

        result.MixtureCount.Should().Be(1);
        result.SampleCount.Should().Be(1);
        result.TestCount.Should().Be(1);
    }
}
