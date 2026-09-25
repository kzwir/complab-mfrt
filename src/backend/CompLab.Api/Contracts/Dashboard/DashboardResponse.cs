namespace CompLab.Api.Contracts.Dashboard;

public sealed class DashboardResponse
{
    public int MixtureCount { get; init; }

    public int SampleCount { get; init; }

    public int TestCount { get; init; }
}
