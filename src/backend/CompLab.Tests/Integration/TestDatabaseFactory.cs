using CompLab.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CompLab.Tests.Integration;

public static class TestDatabaseFactory
{
    public static CompLabDbContext Create()
    {
        var options =
            new DbContextOptionsBuilder<CompLabDbContext>()
                .UseInMemoryDatabase(
                    Guid.NewGuid().ToString())
                .Options;

        return new CompLabDbContext(options);
    }
}
