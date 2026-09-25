using CompLab.Application.DTOs.Mixtures;
using CompLab.Domain.Entities;

namespace CompLab.Application.Mappings;

public static class MixtureMappings
{
    public static MixtureDto ToDto(this Mixture mixture)
    {
        return new MixtureDto
        {
            MixtureId = mixture.MixtureId,
            Code = mixture.Code,
            PolymerPercent = mixture.PolymerPercent,
            QuartzitePercent = mixture.QuartzitePercent
        };
    }
}
