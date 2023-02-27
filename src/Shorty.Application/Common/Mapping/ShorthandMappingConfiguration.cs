namespace Shorty.Application.Common.Mapping;

using Mapster;
using Shorty.Application.Shorthands.Queries.GetAllShorthands;
using Shorty.Domain;

internal static class ShorthandMappingConfiguration
{
    public static void Apply()
    {
        TypeAdapterConfig.GlobalSettings
            .ForType<Shorthand, ShorthandDto>()
            .Map(dest => dest.Id, src => src.Url)
            .TwoWays();
    }
}
