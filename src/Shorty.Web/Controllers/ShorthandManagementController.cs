namespace Shorty.Web.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shorty.Application.Shorthands.Commands.CreateShorthand;
using Shorty.Application.Shorthands.Commands.DeleteShorthand;
using Shorty.Application.Shorthands.Commands.UpdateShorthand;
using Shorty.Application.Shorthands.Queries.GetAllShorthands;

[ApiController]
[Route("api/shorthands")]
public class ShorthandManagementController : Controller
{
    private readonly ISender mediator;

    public ShorthandManagementController(ISender mediator)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    public async Task<IEnumerable<ShorthandDto>> Get()
    {
        return await this.mediator.Send(new GetAllShorthandsQuery());
    }

    [HttpPatch("{id}")]
    public async Task Patch([FromRoute] string id, [FromBody] UpdateShorthandCommand data)
    {
        _ = data ?? throw new ArgumentNullException(nameof(data));

        data.Id = id;
        await this.mediator.Send(data);
    }

    [HttpPost]
    public async Task<string> Post([FromBody] CreateShorthandCommand data)
    {
        return await this.mediator.Send(data);
    }

    [HttpDelete("{id}")]
    public async Task Delete([FromRoute] string id)
    {
        await this.mediator.Send(new DeleteShorthandCommand(id));
    }
}
