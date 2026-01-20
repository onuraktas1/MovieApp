using MediatR;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;

namespace MovieApi.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CastsController : ControllerBase
{
    private readonly IMediator _mediator;

    public CastsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> CastList()
    {
        var value = await _mediator.Send(new GetCastQuery());
        return Ok(value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> CastGetById(int id)
    {
        var value = await _mediator.Send(new GetCastByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public async Task<IActionResult> CastCreate([FromBody] CreateCastCommand command)
    {
        await _mediator.Send(command);
        return Ok("Ekleme işlemi başarılı");
    }

    [HttpDelete]
    public async Task<IActionResult> CastDelete(int id)
    {
        await _mediator.Send(new RemoveCastCommand(id));
        return Ok("Silme işlemi başarılı");
    }

    [HttpPut]
    public async Task<IActionResult> CastUpdate([FromBody] UpdateCastCommand command)
    {
        await _mediator.Send(command);
        return Ok("Güncelleme başarılı");
    }
}