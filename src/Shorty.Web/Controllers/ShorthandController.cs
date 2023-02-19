namespace Shorty.Web.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shorty.Application.Shorthands.Commands.DeleteOutdatedShorthands;
using Shorty.Application.Shorthands.Queries.GetShorthand;

[ApiController]
[Route("s")]
public class ShorthandController : ControllerBase
{
    private readonly ISender mediator;

    public ShorthandController(ISender mediator)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get([FromRoute] string id)
    {
#pragma warning disable CS4014
        // This is not awaited, as a temporary work around.
        this.mediator.Send(new DeleteOutdatedShorthandsCommand());
#pragma warning restore CS4014
        var result = await this.mediator.Send(new GetShorthandQuery { Id = id });

        return this.Redirect(result);
    }
}
