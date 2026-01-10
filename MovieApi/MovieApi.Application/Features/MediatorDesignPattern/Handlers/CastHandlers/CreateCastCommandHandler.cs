using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers;

public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
{
    private readonly MovieContext _context;

    public CreateCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
    {
        _context.Casts.Add(new Cast
        {
            Biography = request.Biography,
            ImageUrl = request.ImageUrl,
            Surname = request.Surname,
            Name = request.Name,
            Title = request.Title,
            Overview = request.Overview,
        });
        await _context.SaveChangesAsync();
    }
}