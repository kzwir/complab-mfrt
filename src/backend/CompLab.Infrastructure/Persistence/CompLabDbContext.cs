using CompLab.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompLab.Infrastructure.Persistence;

public sealed class CompLabDbContext : DbContext
{
    public CompLabDbContext(
        DbContextOptions<CompLabDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Mixture> Mixtures => Set<Mixture>();

    public DbSet<Sample> Samples => Set<Sample>();

    public DbSet<Test> Tests => Set<Test>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
