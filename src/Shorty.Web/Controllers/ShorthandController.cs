namespace Shorty.Web.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        var result = await this.mediator.Send(new GetShorthandQuery { Id = id });

        return this.Redirect(result);
    }
}
