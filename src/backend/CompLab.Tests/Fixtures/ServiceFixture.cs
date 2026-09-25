using CompLab.Application.Abstractions;
using CompLab.Application.Abstractions.Repositories;
using Moq;

namespace CompLab.Tests.Fixtures;

public sealed class ServiceFixture
{
    public Mock<IMixtureRepository> MixtureRepository { get; } = new();

    public Mock<ISampleRepository> SampleRepository { get; } = new();

    public Mock<ITestRepository> TestRepository { get; } = new();

    public Mock<IUserRepository> UserRepository { get; } = new();

    public Mock<IUnitOfWork> UnitOfWork { get; } = new();

    public Mock<IJwtTokenGenerator> JwtTokenGenerator { get; } = new();

    public Mock<IPasswordHasher> PasswordHasher { get; } = new();
}
