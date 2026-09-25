namespace CompLab.Application.DTOs.Tests;

public sealed class TestDto
{
    public Guid TestId { get; init; }

    public Guid SampleId { get; init; }

    public string TestType { get; init; } = string.Empty;

    public decimal MeasurementValue { get; init; }

    public DateTime CreatedAt { get; init; }
}
