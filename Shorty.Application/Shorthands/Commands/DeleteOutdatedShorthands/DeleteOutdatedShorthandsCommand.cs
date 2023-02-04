namespace Shorty.Application.Shorthands.Commands.DeleteOutdatedShorthands;

using MediatR;

public record DeleteOutdatedShorthandsCommand : IRequest<Unit>;
