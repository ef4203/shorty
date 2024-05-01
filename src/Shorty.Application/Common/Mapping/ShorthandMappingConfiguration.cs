namespace Shorty.Application.Common.Mapping;

using Mapster;
using Shorty.Application.Shorthands.Queries.GetAllShorthands;
using Shorty.Domain;

public static class ShorthandMappingConfiguration
{
    public static void Apply()
    {
        TypeAdapterConfig.GlobalSettings
            .ForType<Shorthand, ShorthandDto>()
            .Map(dest => dest.Id, src => src.Url)
            .Map(dest => dest.ExpirationDate, src => ComputeExpirationDate(src))
            .TwoWays();
    }

    public static DateTime? ComputeExpirationDate(Shorthand src)
    {
        ArgumentNullException.ThrowIfNull(src);

        if (src.ExpiresAfterDays < 0)
        {
            return null;
        }

        return src.DateAdded.AddDays(src.ExpiresAfterDays);
    }
}
