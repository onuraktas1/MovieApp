using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers;

public class RemoveTagCommandGHandler : IRequestHandler<RemoveTagCommand>
{
    private readonly MovieContext _context;

    public RemoveTagCommandGHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveTagCommand request, CancellationToken cancellationToken)
    {
        var value = await _context.Tags.FindAsync(request.TagId);
        _context.Tags.Remove(value);
        await _context.SaveChangesAsync();
    }
}