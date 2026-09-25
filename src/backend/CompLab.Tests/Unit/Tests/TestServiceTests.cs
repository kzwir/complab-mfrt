using CompLab.Application.Services.Tests;
using CompLab.Domain.Entities;
using CompLab.Domain.Enums;
using CompLab.Tests.Fixtures;

namespace CompLab.Tests.Unit.Tests;

public sealed class TestServiceTests
{
    [Fact]
    public async Task CreateAsync_ShouldCreateTest()
    {
        var fixture = new ServiceFixture();

        var service = new TestService(
            fixture.TestRepository.Object,
            fixture.UnitOfWork.Object);

        var id = await service.CreateAsync(
            Guid.NewGuid(),
            TestType.Mfr,
            12.5m);

        id.Should().NotBeEmpty();

        fixture.TestRepository.Verify(
            x => x.AddAsync(
                It.IsAny<Test>(),
                default),
            Times.Once);
    }

    [Fact]
    public async Task CreateAsync_ShouldThrow_WhenValueIsZero()
    {
        var fixture = new ServiceFixture();

        var service = new TestService(
            fixture.TestRepository.Object,
            fixture.UnitOfWork.Object);

        var action = async () =>
            await service.CreateAsync(
                Guid.NewGuid(),
                TestType.Mfr,
                0);

        await action.Should()
            .ThrowAsync<Exception>();
    }
}
``
