namespace Shorty.Application.Common.Mapping;

using Mapster;
using Shorty.Application.Shorthands.Queries.GetAllShorthands;
using Shorty.Domain;

internal sealed class ShorthandMappingConfiguration
{
    public ShorthandMappingConfiguration()
    {
        TypeAdapterConfig.GlobalSettings
            .ForType<Shorthand, ShorthandDto>()
            .Map(dest => dest.Id, src => src.Url)
            .TwoWays();
    }
}
