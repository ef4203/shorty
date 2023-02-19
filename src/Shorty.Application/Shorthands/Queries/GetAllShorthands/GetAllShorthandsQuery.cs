namespace Shorty.Application.Shorthands.Queries.GetAllShorthands;

using MediatR;

public record GetAllShorthandsQuery : IRequest<IEnumerable<ShorthandDto>>;
