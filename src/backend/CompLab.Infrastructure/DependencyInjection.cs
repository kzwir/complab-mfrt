using CompLab.Application.Abstractions;
using CompLab.Application.Abstractions.Repositories;
using CompLab.Infrastructure.Authentication;
using CompLab.Infrastructure.Persistence;
using CompLab.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompLab.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtOptions>(
            configuration.GetSection(
                JwtOptions.SectionName));

        services.AddDbContext<CompLabDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString(
                    "DefaultConnection"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IMixtureRepository, MixtureRepository>();

        services.AddScoped<ISampleRepository, SampleRepository>();

        services.AddScoped<ITestRepository, TestRepository>();

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
