namespace Shorty.Application.Shorthands.Commands.CreateShorthand;

using MediatR;

public record CreateShorthandCommand : IRequest<string>
{
    public string? Destination { get; set; }

    public int ExpiresAfterDays { get; set; }
}
