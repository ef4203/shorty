namespace Shorty.Application.Shorthands.Queries.GetShorthand;

using MediatR;

public record GetShorthandQuery : IRequest<string>
{
    public string? Id { get; set; }
}
