using CompLab.Application.Services.Samples;
using CompLab.Domain.Entities;
using CompLab.Tests.Fixtures;

namespace CompLab.Tests.Unit.Samples;

public sealed class SampleServiceTests
{
    [Fact]
    public async Task CreateAsync_ShouldCreateSample()
    {
        var fixture = new ServiceFixture();

        var service = new SampleService(
            fixture.SampleRepository.Object,
            fixture.UnitOfWork.Object);

        var id = await service.CreateAsync(
            Guid.NewGuid(),
            "SMP-001",
            DateOnly.FromDateTime(DateTime.Today));

        id.Should().NotBeEmpty();

        fixture.SampleRepository.Verify(
            x => x.AddAsync(
                It.IsAny<Sample>(),
                default),
            Times.Once);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnSamples()
    {
        var fixture = new ServiceFixture();

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

        var service = new SampleService(
            fixture.SampleRepository.Object,
            fixture.UnitOfWork.Object);

        var result = await service.GetAllAsync();

        result.Should().HaveCount(1);
    }
}
