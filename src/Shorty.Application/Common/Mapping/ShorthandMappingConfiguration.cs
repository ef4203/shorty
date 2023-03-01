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
            .Map(dest => dest.ExpirationDate, src => ComputeExpirationDate(src))
            .TwoWays();
    }

    private static DateTime? ComputeExpirationDate(Shorthand src)
    {
        if (src.ExpiresAfterDays < 0)
        {
            return null;
        }

        return src.DateAdded.AddDays(src.ExpiresAfterDays);
    }
}
