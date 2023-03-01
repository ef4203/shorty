namespace Shorty.Application.Shorthands.Commands.DeleteOutdatedShorthands;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Shorty.Application.Common.Abstraction;

[UsedImplicitly]
internal sealed class DeleteOutdatedShorthandsCommandHandler : IRequestHandler<DeleteOutdatedShorthandsCommand>
{
    private readonly IApplicationContext dbContext;

    public DeleteOutdatedShorthandsCommandHandler(IApplicationContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task Handle(DeleteOutdatedShorthandsCommand request, CancellationToken cancellationToken)
    {
        var toRemove = await this.dbContext.Shorthands
            .Where(x => x.ExpiresAfterDays > 0)
            .Where(x => x.DateAdded.AddDays(x.ExpiresAfterDays) > DateTime.UtcNow)
            .ToArrayAsync(cancellationToken);

        this.dbContext.Shorthands.RemoveRange(toRemove);
        await this.dbContext.SaveChangesAsync(cancellationToken);
    }
}
