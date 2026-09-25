using CompLab.Domain.Entities;
using CompLab.Infrastructure.Repositories;
using CompLab.Tests.Integration.Fixtures;

namespace CompLab.Tests.Integration.Repositories;

public sealed class SampleRepositoryTests
{
    [Fact]
    public async Task AddAsync_ShouldSaveSample()
    {
        using var fixture =
            new DatabaseFixture();

        var repository =
            new SampleRepository(
                fixture.DbContext);

        var sample = new Sample(
            Guid.NewGuid(),
            Guid.NewGuid(),
            "SMP-001",
            DateOnly.FromDateTime(DateTime.Today));

        await repository.AddAsync(sample);

        await fixture.DbContext.SaveChangesAsync();

        var stored =
            await repository.GetByIdAsync(
                sample.SampleId);

        stored.Should().NotBeNull();
    }
}
