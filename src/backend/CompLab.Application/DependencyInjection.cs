using CompLab.Application.Services.Auth;
using CompLab.Application.Services.Dashboard;
using CompLab.Application.Services.Mixtures;
using CompLab.Application.Services.Samples;
using CompLab.Application.Services.Tests;
using Microsoft.Extensions.DependencyInjection;

namespace CompLab.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();

        services.AddScoped<IMixtureService, MixtureService>();

        services.AddScoped<ISampleService, SampleService>();

        services.AddScoped<ITestService, TestService>();

        services.AddScoped<IDashboardService, DashboardService>();

        return services;
    }
}
