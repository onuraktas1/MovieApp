using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers;

public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
{
    private readonly MovieContext _context;

    public GetCastQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Casts.ToListAsync();
        return values.Select(x => new GetCastQueryResult
        {
            Biography = x.Biography,
            ImageUrl = x.ImageUrl,
            CastId = x.CastId,
            Name = x.Name,
            Surname = x.Surname,
            Overview = x.Overview,
            Title = x.Title
        }).ToList();
    }
}