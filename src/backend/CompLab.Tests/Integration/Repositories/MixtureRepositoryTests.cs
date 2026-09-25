using CompLab.Domain.Entities;
using CompLab.Infrastructure.Repositories;
using CompLab.Tests.Integration.Fixtures;

namespace CompLab.Tests.Integration.Repositories;

public sealed class MixtureRepositoryTests
{
    [Fact]
    public async Task AddAsync_ShouldPersistEntity()
    {
        using var fixture =
            new DatabaseFixture();

        var repository =
            new MixtureRepository(
                fixture.DbContext);

        var mixture = new Mixture(
            Guid.NewGuid(),
            "MIX-001",
            40,
            60);

        await repository.AddAsync(mixture);

        await fixture.DbContext.SaveChangesAsync();

        var stored =
            await repository.GetByIdAsync(
                mixture.MixtureId);

        stored.Should().NotBeNull();

        stored!.Code.Should().Be("MIX-001");
    }
}
