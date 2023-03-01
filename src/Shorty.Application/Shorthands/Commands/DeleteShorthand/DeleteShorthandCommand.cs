namespace Shorty.Application.Shorthands.Commands.DeleteShorthand;

using MediatR;

public record DeleteShorthandCommand(string? Id) : IRequest
{
    public string? Id { get; set; } = Id;
}
