using CompLab.Domain.Entities;
using CompLab.Infrastructure.Repositories;
using CompLab.Tests.Integration.Fixtures;

namespace CompLab.Tests.Integration.Repositories;

public sealed class TestRepositoryTests
{
    [Fact]
    public async Task AddAsync_ShouldSaveTest()
    {
        using var fixture =
            new DatabaseFixture();

        var repository =
            new TestRepository(
                fixture.DbContext);

        var entity = new Test(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "MFR",
            12.5m,
            DateTime.UtcNow);

        await repository.AddAsync(entity);

        await fixture.DbContext.SaveChangesAsync();

        var stored =
            await repository.GetByIdAsync(
                entity.TestId);

        stored.Should().NotBeNull();
    }
}
