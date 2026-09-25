using CompLab.Api.Contracts.Auth;
using CompLab.Application.DTOs.Auth;
using CompLab.Application.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CompLab.Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public sealed class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        LoginRequest request,
        CancellationToken cancellationToken)
    {
        var result = await _authService.LoginAsync(
            new LoginDto
            {
                Email = request.Email,
                Password = request.Password
            },
            cancellationToken);

        if (result is null)
        {
            return Unauthorized();
        }

        return Ok(new LoginResponse
        {
            Token = result.Token,
            ExpiresIn = result.ExpiresIn
        });
    }
}
