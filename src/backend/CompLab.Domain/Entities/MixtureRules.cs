using CompLab.Domain.Exceptions;

namespace CompLab.Domain.Rules;

public static class MixtureRules
{
    public static void ValidateComposition(
        decimal polymerPercent,
        decimal quartzitePercent)
    {
        if (polymerPercent < 0)
        {
            throw new DomainException(
                "PolymerPercent cannot be negative.");
        }

        if (quartzitePercent < 0)
        {
            throw new DomainException(
                "QuartzitePercent cannot be negative.");
        }

        if (polymerPercent + quartzitePercent != 100)
        {
            throw new DomainException(
                "Mixture composition must equal 100%.");
        }
    }
}
