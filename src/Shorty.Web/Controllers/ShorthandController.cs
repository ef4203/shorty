namespace Shorty.Web.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shorty.Application.Shorthands.Commands.CreateShorthand;
using Shorty.Application.Shorthands.Commands.DeleteOutdatedShorthands;
using Shorty.Application.Shorthands.Commands.UpdateShorthand;
using Shorty.Application.Shorthands.Queries.GetShorthand;

[ApiController]
[Route("s")]
public class ShorthandController : ControllerBase
{
    private readonly ISender mediatr;

    public ShorthandController(ISender mediatr)
    {
        this.mediatr = mediatr ?? throw new ArgumentNullException(nameof(mediatr));
    }

    [HttpGet("{url}")]
    public async Task<ActionResult> Get([FromRoute] string url)
    {
        this.mediatr.Send(new DeleteOutdatedShorthandsCommand());
        var result = await this.mediatr.Send(new GetShorthandQuery { Id = url });

        return this.Redirect(result);
    }

    [HttpPost]
    public async Task<string> Post([FromBody] CreateShorthandCommand data)
    {
        return await this.mediatr.Send(data);
    }

    [HttpPatch]
    public async Task Patch(
        [FromBody] UpdateShorthandCommand data) 
        => await this.mediatr.Send(data);
}
