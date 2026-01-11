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
    public IActionResult CastList()
    {
        var value = _mediator.Send(new GetCastQuery());
        return Ok(value);
    }

    [HttpGet("{id}")]
    public IActionResult CastGetById(int id)
    {
        var value = _mediator.Send(new GetCastByIdQuery(id));
        return Ok(value);
    }

    [HttpPost]
    public IActionResult CastCreate([FromBody] CreateCastCommand command)
    {
        _mediator.Send(command);
        return Ok("Ekleme işlemi başarılı");
    }

    [HttpDelete]
    public IActionResult CastDelete(int id)
    {
        _mediator.Send(new RemoveCastCommand(id));
        return Ok("Silme işlemi başarılı");
    }

    [HttpPut("{id}")]
    public IActionResult CastUpdate([FromBody] UpdateCastCommand command)
    {
        _mediator.Send(command);
        return Ok("Güncelleme başarılı");
    }
}