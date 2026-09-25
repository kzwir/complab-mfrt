namespace CompLab.Domain.Entities;

public sealed class Test
{
    public Guid TestId { get; private set; }

    public Guid SampleId { get; private set; }

    public string TestType { get; private set; } = string.Empty;

    public decimal MeasurementValue { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public Sample? Sample { get; private set; }

    private Test()
    {
    }

    public Test(
        Guid testId,
        Guid sampleId,
        string testType,
        decimal measurementValue,
        DateTime createdAt)
    {
        TestId = testId;
        SampleId = sampleId;
        TestType = testType;
        MeasurementValue = measurementValue;
        CreatedAt = createdAt;
    }

    public void UpdateMeasurement(decimal measurementValue)
    {
        MeasurementValue = measurementValue;
    }
}
