namespace CompLab.Api.Contracts.Tests;

public sealed class CreateTestRequest
{
    public Guid SampleId { get; init; }

    public string TestType { get; init; } = string.Empty;

    public decimal MeasurementValue { get; init; }
}
``
