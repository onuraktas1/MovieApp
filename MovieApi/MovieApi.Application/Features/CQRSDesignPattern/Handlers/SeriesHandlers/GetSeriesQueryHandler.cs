using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.SeriesQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.SeriesResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;

public class GetSeriesQueryHandler
{
    private readonly MovieContext _context;

    public GetSeriesQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetSeriesQueryResult>> Handle()
    {
        var result = await _context.Serieses.ToListAsync();

        return result.Select(x => new GetSeriesQueryResult
        {
            SeriesId = x.SeriesId,
            CoverImageUrl = x.CoverImageUrl,
            CreatedYear = x.CreatedYear,
            Description = x.Description,
            FirstAirDate = x.FirstAirDate,
            EpisodeCount = x.EpisodeCount,
            AverageEpisodeDuration = x.AverageEpisodeDuration,
            SeasonCount = x.SeasonCount,
            Rating = x.Rating,
            Title = x.Title,
            Status = x.Status,
            CategoryId = x.CategoryId
        }).ToList();
    }
}