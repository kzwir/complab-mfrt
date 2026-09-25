namespace CompLab.Application.DTOs.Samples;

public sealed class SampleDto
{
    public Guid SampleId { get; init; }

    public Guid MixtureId { get; init; }

    public string SampleNumber { get; init; } = string.Empty;

    public DateOnly ProductionDate { get; init; }
}
