namespace CompLab.Api.Contracts.Samples;

public sealed class CreateSampleRequest
{
    public Guid MixtureId { get; init; }

    public string SampleNumber { get; init; } = string.Empty;

    public DateOnly ProductionDate { get; init; }
}
``
