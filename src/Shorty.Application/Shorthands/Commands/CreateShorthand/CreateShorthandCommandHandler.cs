namespace Shorty.Application.Shorthands.Commands.CreateShorthand;

using MediatR;
using Shorty.Application.Common.Abstraction;
using Shorty.Domain;

[UsedImplicitly]
internal sealed class CreateShorthandCommandHandler : IRequestHandler<CreateShorthandCommand, string>
{
    private readonly IApplicationContext dbContext;

    public CreateShorthandCommandHandler(IApplicationContext dbContext)
    {
        this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<string> Handle(CreateShorthandCommand request, CancellationToken cancellationToken)
    {
        _ = request ?? throw new ArgumentNullException(nameof(request));

        var shorthand = new Shorthand
        {
            Url = Guid.NewGuid().ToString("n")[..5],
            Destination = request.Destination,
            DateAdded = DateTime.UtcNow,
        };

        this.dbContext.Shorthands.Add(shorthand);
        await this.dbContext.SaveChangesAsync(cancellationToken);

        return shorthand.Url;
    }
}
