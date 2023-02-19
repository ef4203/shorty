namespace Shorty.Application.Shorthands.Queries.GetShorthand;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Shorty.Application.Common.Abstraction;
using Shorty.Application.Common.Exceptions;

[UsedImplicitly]
internal sealed class GetShorthandQueryHandler : IRequestHandler<GetShorthandQuery, string>
{
    private readonly IApplicationContext dbContext;

    public GetShorthandQueryHandler(IApplicationContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<string> Handle(GetShorthandQuery request, CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request));

        var result = await this.dbContext.Shorthands
            .Where(x => x.Url == request.Id)
            .FirstOrDefaultAsync(cancellationToken);

        _ = result?.Destination ?? throw new NotFoundException();

        return result.Destination;
    }
}
