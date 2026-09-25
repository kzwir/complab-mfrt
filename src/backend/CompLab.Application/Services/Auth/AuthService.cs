using CompLab.Application.Abstractions;
using CompLab.Application.Abstractions.Repositories;
using CompLab.Application.DTOs.Auth;

namespace CompLab.Application.Services.Auth;

public sealed class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginResultDto?> LoginAsync(
        LoginDto request,
        CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByEmailAsync(
            request.Email,
            cancellationToken);

        if (user is null)
        {
            return null;
        }

        var verified = _passwordHasher.Verify(
            request.Password,
            user.PasswordHash);

        if (!verified)
        {
            return null;
        }

        var token = _jwtTokenGenerator.Generate(
            user.UserId,
            user.Email,
            user.Role);

        return new LoginResultDto
        {
            Token = token,
            ExpiresIn = 3600
        };
    }
}
