using CompLab.Infrastructure.Persistence;

namespace CompLab.Tests.Integration.Fixtures;

public sealed class DatabaseFixture : IDisposable
{
    public CompLabDbContext DbContext { get; }

    public DatabaseFixture()
    {
        DbContext = TestDatabaseFactory.Create();
    }

    public void Dispose()
    {
        DbContext.Dispose();
    }
}
