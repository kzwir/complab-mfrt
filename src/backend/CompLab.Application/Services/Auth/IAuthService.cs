using CompLab.Application.DTOs.Auth;

namespace CompLab.Application.Services.Auth;

public interface IAuthService
{
    Task<LoginResultDto?> LoginAsync(
        LoginDto request,
        CancellationToken cancellationToken = default);
}
