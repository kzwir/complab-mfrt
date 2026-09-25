namespace CompLab.Application.DTOs.Mixtures;

public sealed class MixtureDto
{
    public Guid MixtureId { get; init; }

    public string Code { get; init; } = string.Empty;

    public decimal PolymerPercent { get; init; }

    public decimal QuartzitePercent { get; init; }
}
