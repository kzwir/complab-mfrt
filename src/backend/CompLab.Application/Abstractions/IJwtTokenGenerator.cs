namespace CompLab.Application.Abstractions;

public interface IJwtTokenGenerator
{
    string Generate(
        Guid userId,
        string email,
        string role);
}
