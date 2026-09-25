namespace CompLab.Api.Contracts.Auth;

public sealed class LoginResponse
{
    public string Token { get; init; } = string.Empty;

    public int ExpiresIn { get; init; }
}
