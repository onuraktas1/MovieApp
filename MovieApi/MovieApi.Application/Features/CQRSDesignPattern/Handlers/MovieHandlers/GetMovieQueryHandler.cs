using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class GetMovieQueryHandler
{
    private readonly MovieContext _context;

    public GetMovieQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetMovieQueryResult>> Handle()
    {
        var result = _context.Movies.ToList();

        return result.Select(x => new GetMovieQueryResult
        {
            MovieId = x.MovieId,
            CoverImageUrl = x.CoverImageUrl,
            CreatedYear = x.CreatedYear,
            Description = x.Description,
            Duration = x.Duration,
            ReleaseDate = x.ReleaseDate,
            Title = x.Title,
            Status = x.Status,
            Rating = x.Rating,
        }).ToList();
    }
}