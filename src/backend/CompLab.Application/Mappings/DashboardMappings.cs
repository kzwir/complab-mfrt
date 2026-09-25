using CompLab.Application.DTOs.Dashboard;

namespace CompLab.Application.Mappings;

public static class DashboardMappings
{
    public static DashboardDto Create(
        int mixtureCount,
        int sampleCount,
        int testCount)
    {
        return new DashboardDto
        {
            MixtureCount = mixtureCount,
            SampleCount = sampleCount,
            TestCount = testCount
        };
    }
}
