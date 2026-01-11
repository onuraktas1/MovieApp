using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers;

public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
{
    private readonly MovieContext _context;

    public UpdateTagCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var value = await _context.Tags.FindAsync(request.TagId);
        value.Title = request.Title;
        _context.Tags.Update(value);
        await _context.SaveChangesAsync();
    }
}