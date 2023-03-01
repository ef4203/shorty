namespace Shorty.Application.Shorthands.Commands.UpdateShorthand;

using MediatR;
using Shorty.Application.Common.Abstraction;
using Shorty.Application.Common.Exceptions;

[UsedImplicitly]
internal sealed class UpdateShorthandCommandHandler : IRequestHandler<UpdateShorthandCommand>
{
    private readonly IApplicationContext dbContext;

    public UpdateShorthandCommandHandler(IApplicationContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task Handle(
        UpdateShorthandCommand request,
        CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request));

        var entity = await this.dbContext.Shorthands
            .FindAsync(new object?[] { request.Id }, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException($"The entry was not found by given parameter {request.Id}.");
        }

        entity.Destination = request.Destination;
        entity.ExpiresAfterDays = request.ExpiresAfterDays;

        this.dbContext.Shorthands.Update(entity);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
