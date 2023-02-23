namespace Shorty.Application.Shorthands.Commands.DeleteShorthand;

using MediatR;
using Shorty.Application.Common.Abstraction;
using Shorty.Application.Common.Exceptions;

public record DeleteShorthandCommand(string? Url) : IRequest;

internal sealed class DeleteShorthandCommandHandler
    : BaseHandler, IRequestHandler<DeleteShorthandCommand>
{
    public DeleteShorthandCommandHandler(IApplicationContext dbContext) : base(dbContext) 
    {
    }

    public async Task Handle(
        DeleteShorthandCommand request, 
        CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request));

        var entity = await this.dbContext.Shorthands.FindAsync(request.Url);
        if (entity == null)
        {
            throw new NotFoundException($"The entry was not found by given parameter {request.Url}.");
        }

        this.dbContext.Shorthands.Remove(entity);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
