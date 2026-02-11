using MovieApi.Application.Features.CQRSDesignPattern.Queries.SeriesQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Application.Features.CQRSDesignPattern.Results.SeriesResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;

public class GetSeriesByIdQueryHandler
{
    private readonly MovieContext _context;

    public GetSeriesByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetSeriesByIdQueryResult> Handle(GetSeriesByIdQuery query)
    {
        var result = await _context.Serieses.FindAsync(query.SeriesId);
        return new GetSeriesByIdQueryResult
        {
            SeriesId =  result.SeriesId,
            CoverImageUrl = result.CoverImageUrl,
            CreatedYear = result.CreatedYear,
            Description = result.Description,
            FirstAirDate = result.FirstAirDate,
            EpisodeCount = result.EpisodeCount,
            AverageEpisodeDuration = result.AverageEpisodeDuration,
            SeasonCount = result.SeasonCount,
            Rating = result.Rating,
            Title = result.Title,
            Status = result.Status,
            CategoryId = result.CategoryId
        };
    }
}