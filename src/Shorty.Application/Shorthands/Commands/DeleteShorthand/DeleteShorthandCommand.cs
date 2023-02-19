namespace Shorty.Application.Shorthands.Commands.DeleteShorthand;

using MediatR;
using Shorty.Application.Common.Abstraction;
using Shorty.Application.Common.Exceptions;

public record DeleteShorthandCommand(string? Id) : IRequest
{
    public string? Id { get; set; } = Id;
}

[UsedImplicitly]
internal sealed class DeleteShorthandCommandHandler : IRequestHandler<DeleteShorthandCommand>
{
    private readonly IApplicationContext dbContext;

    public DeleteShorthandCommandHandler(IApplicationContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task Handle(DeleteShorthandCommand request, CancellationToken cancellationToken)
    {
        var result = await this.dbContext.Shorthands
            .FindAsync(new object?[] { request.Id }, cancellationToken);

        if (result is null)
        {
            throw new NotFoundException($"The entry was not found by given parameter {request.Id}.");
        }

        this.dbContext.Shorthands.Remove(result);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
