using CompLab.Domain.Exceptions;

namespace CompLab.Domain.Rules;

public static class SampleRules
{
    public static void Validate(string sampleNumber)
    {
        if (string.IsNullOrWhiteSpace(sampleNumber))
        {
            throw new DomainException(
                "Sample number is required.");
        }
    }
}
