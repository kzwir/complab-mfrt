using CompLab.Application.Services.Mixtures;
using CompLab.Domain.Entities;
using CompLab.Tests.Fixtures;

namespace CompLab.Tests.Unit.Mixtures;

public sealed class MixtureServiceTests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnMixtures()
    {
        var fixture = new ServiceFixture();

        fixture.MixtureRepository
            .Setup(x => x.GetAllAsync(default))
            .ReturnsAsync(
            [
                new Mixture(
                    Guid.NewGuid(),
                    "MIX-001",
                    40,
                    60)
            ]);

        var service = new MixtureService(
            fixture.MixtureRepository.Object,
            fixture.UnitOfWork.Object);

        var result = await service.GetAllAsync();

        result.Should().NotBeEmpty();

        result.Count.Should().Be(1);
    }

    [Fact]
    public async Task CreateAsync_ShouldCreateMixture()
    {
        var fixture = new ServiceFixture();

        var service = new MixtureService(
            fixture.MixtureRepository.Object,
            fixture.UnitOfWork.Object);

        var id = await service.CreateAsync(
            "MIX-001",
            40,
            60);

        id.Should().NotBeEmpty();

        fixture.MixtureRepository.Verify(
            x => x.AddAsync(
                It.IsAny<Mixture>(),
                default),
            Times.Once);
    }
}
