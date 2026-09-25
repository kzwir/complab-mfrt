using CompLab.Application.DTOs.Tests;
using CompLab.Domain.Entities;

namespace CompLab.Application.Mappings;

public static class TestMappings
{
    public static TestDto ToDto(this Test test)
    {
        return new TestDto
        {
            TestId = test.TestId,
            SampleId = test.SampleId,
            TestType = test.TestType,
            MeasurementValue = test.MeasurementValue,
            CreatedAt = test.CreatedAt
        };
    }
}
