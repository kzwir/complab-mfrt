using CompLab.Application.DTOs.Samples;
using CompLab.Domain.Entities;

namespace CompLab.Application.Mappings;

public static class SampleMappings
{
    public static SampleDto ToDto(this Sample sample)
    {
        return new SampleDto
        {
            SampleId = sample.SampleId,
            MixtureId = sample.MixtureId,
            SampleNumber = sample.SampleNumber,
            ProductionDate = sample.ProductionDate
        };
    }
}
