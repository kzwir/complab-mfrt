namespace CompLab.Api.Contracts.Mixtures;

public sealed class CreateMixtureRequest
{
    public string Code { get; init; } = string.Empty;

    public decimal PolymerPercent { get; init; }

    public decimal QuartzitePercent { get; init; }
}
