namespace Shorty.Application.Shorthands.Queries.GetAllShorthands;

using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shorty.Application.Common.Abstraction;

[UsedImplicitly]
internal sealed class GetAllShorthandsQueryHandler : IRequestHandler<GetAllShorthandsQuery, IEnumerable<ShorthandDto>>
{
    private readonly IApplicationContext dbContext;

    public GetAllShorthandsQueryHandler(IApplicationContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IEnumerable<ShorthandDto>> Handle(
        GetAllShorthandsQuery request,
        CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request));

        return await this.dbContext.Shorthands
            .ProjectToType<ShorthandDto>()
            .ToArrayAsync(cancellationToken);
    }
}
