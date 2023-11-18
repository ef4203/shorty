namespace Shorty.Application.Shorthands.Queries.GetAllShorthands;

using MediatR;

#pragma warning disable S2094
public record GetAllShorthandsQuery : IRequest<IEnumerable<ShorthandDto>>;
#pragma warning restore S2094
