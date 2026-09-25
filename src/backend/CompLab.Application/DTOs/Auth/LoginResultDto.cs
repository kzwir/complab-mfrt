namespace CompLab.Application.DTOs.Auth;

public sealed class LoginResultDto
{
    public string Token { get; init; } = string.Empty;

    public int ExpiresIn { get; init; }
}
