namespace CompLab.Domain.Entities;

public sealed class Sample
{
    public Guid SampleId { get; private set; }

    public Guid MixtureId { get; private set; }

    public string SampleNumber { get; private set; } = string.Empty;

    public DateOnly ProductionDate { get; private set; }

    public Mixture? Mixture { get; private set; }

    private readonly List<Test> _tests = [];

    public IReadOnlyCollection<Test> Tests => _tests;

    private Sample()
    {
    }

    public Sample(
        Guid sampleId,
        Guid mixtureId,
        string sampleNumber,
        DateOnly productionDate)
    {
        SampleId = sampleId;
        MixtureId = mixtureId;
        SampleNumber = sampleNumber;
        ProductionDate = productionDate;
    }

    public void UpdateSampleNumber(string sampleNumber)
    {
        SampleNumber = sampleNumber;
    }
}
