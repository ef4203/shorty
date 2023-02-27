namespace Shorty.Application.Shorthands.Jobs;

using MediatR;
using Shorty.Application.Common.Abstraction;
using Shorty.Application.Shorthands.Commands.DeleteOutdatedShorthands;

[UsedImplicitly]
public class DeleteOutdatedShorthandsJob : IJob
{
    private readonly ISender mediator;

    public DeleteOutdatedShorthandsJob(ISender mediator)
    {
        this.mediator = mediator;
    }

    public string CronPattern { get; } = "0 0 * * *";

    public async Task Handle()
    {
        await this.mediator.Send(new DeleteOutdatedShorthandsCommand());
    }
}
