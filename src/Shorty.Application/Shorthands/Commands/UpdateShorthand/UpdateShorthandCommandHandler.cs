namespace Shorty.Application.Shorthands.Commands.UpdateShorthand;

using MediatR;
using Shorty.Application.Common.Abstraction;

public class UpdateShorthandCommandHandler : IRequestHandler<UpdateShorthandCommandHandler.UpdateShorthandCommand>
{
    public record UpdateShorthandCommand(string? Url, string? Destination) : IRequest;

    private readonly IApplicationContext dbContext;

    public UpdateShorthandCommandHandler(IApplicationContext dbContext)
    {
        this.dbContext = dbContext 
            ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task Handle(
        UpdateShorthandCommand request, 
        CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request));

        var entity = await this.dbContext.Shorthands.FindAsync(request.Url);
        if (entity == null)
        {
            throw new ArgumentException($"The entry was not found by given parameter {request.Url}.");
        }

        entity.Destination = request.Destination;
        this.dbContext.Shorthands.Update(entity);
        _ = await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
