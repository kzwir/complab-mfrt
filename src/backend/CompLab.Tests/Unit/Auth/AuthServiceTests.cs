using CompLab.Application.DTOs.Auth;
using CompLab.Application.Services.Auth;
using CompLab.Domain.Entities;
using CompLab.Tests.Fixtures;

namespace CompLab.Tests.Unit.Auth;

public sealed class AuthServiceTests
{
    [Fact]
    public async Task Login_ShouldReturnToken()
    {
        var fixture = new ServiceFixture();

        var user = new User(
            Guid.NewGuid(),
            "admin@complab.local",
            "hash",
            "Administrator");

        fixture.UserRepository
            .Setup(x => x.GetByEmailAsync(
                user.Email,
                default))
            .ReturnsAsync(user);

        fixture.PasswordHasher
            .Setup(x => x.Verify(
                It.IsAny<string>(),
                It.IsAny<string>()))
            .Returns(true);

        fixture.JwtTokenGenerator
            .Setup(x => x.Generate(
                It.IsAny<Guid>(),
                It.IsAny<string>(),
                It.IsAny<string>()))
            .Returns("jwt-token");

        var service = new AuthService(
            fixture.UserRepository.Object,
            fixture.PasswordHasher.Object,
            fixture.JwtTokenGenerator.Object);

        var result = await service.LoginAsync(
            new LoginDto
            {
                Email = user.Email,
                Password = "password"
            });

        result.Should().NotBeNull();

        result!.Token.Should().Be("jwt-token");
    }

    [Fact]
    public async Task Login_ShouldReturnNull_WhenPasswordInvalid()
    {
        var fixture = new ServiceFixture();

        var user = new User(
            Guid.NewGuid(),
            "admin@complab.local",
            "hash",
            "Administrator");

        fixture.UserRepository
            .Setup(x => x.GetByEmailAsync(
                user.Email,
                default))
            .ReturnsAsync(user);

        fixture.PasswordHasher
            .Setup(x => x.Verify(
                It.IsAny<string>(),
                It.IsAny<string>()))
            .Returns(false);

        var service = new AuthService(
            fixture.UserRepository.Object,
            fixture.PasswordHasher.Object,
            fixture.JwtTokenGenerator.Object);

        var result = await service.LoginAsync(
            new LoginDto
            {
                Email = user.Email,
                Password = "wrong-password"
            });

        result.Should().BeNull();
    }
}
