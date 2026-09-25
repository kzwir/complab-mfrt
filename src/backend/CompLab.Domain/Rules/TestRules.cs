using CompLab.Domain.Enums;
using CompLab.Domain.Exceptions;

namespace CompLab.Domain.Rules;

public static class TestRules
{
    public static void Validate(
        string testType,
        decimal measurementValue)
    {
        if (measurementValue <= 0)
        {
            throw new DomainException(
                "MeasurementValue must be greater than zero.");
        }

        if (testType != TestType.Mfr &&
            testType != TestType.Strength)
        {
            throw new DomainException(
                "Unsupported test type.");
        }
    }
}
