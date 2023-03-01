namespace Shorty.Application.Shorthands.Commands.UpdateShorthand;

using MediatR;

public record UpdateShorthandCommand(string? Id) : IRequest
{
    public string? Id { get; set; } = Id;

    public string? Destination { get; set; }

    public int ExpiresAfterDays { get; set; }
}
