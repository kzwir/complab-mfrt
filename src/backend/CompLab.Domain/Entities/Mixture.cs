namespace CompLab.Domain.Entities;

public sealed class Mixture
{
    public Guid MixtureId { get; private set; }

    public string Code { get; private set; } = string.Empty;

    public decimal PolymerPercent { get; private set; }

    public decimal QuartzitePercent { get; private set; }

    private readonly List<Sample> _samples = [];

    public IReadOnlyCollection<Sample> Samples => _samples;

    private Mixture()
    {
    }

    public Mixture(
        Guid mixtureId,
        string code,
        decimal polymerPercent,
        decimal quartzitePercent)
    {
        MixtureId = mixtureId;
        Code = code;
        PolymerPercent = polymerPercent;
        QuartzitePercent = quartzitePercent;
    }

    public void UpdateComposition(
        decimal polymerPercent,
        decimal quartzitePercent)
    {
        PolymerPercent = polymerPercent;
        QuartzitePercent = quartzitePercent;
    }
}
