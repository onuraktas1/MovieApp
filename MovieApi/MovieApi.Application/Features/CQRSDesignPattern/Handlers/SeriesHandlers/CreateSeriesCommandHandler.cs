using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;

public class CreateSeriesCommandHandler
{
    private readonly MovieContext _context;

    public CreateSeriesCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateSeriesCommand command)
    {
        _context.Serieses.Add(new Series()
        {
            CoverImageUrl = command.CoverImageUrl,
            CreatedYear = command.CreatedYear,
            Description = command.Description,
            FirstAirDate = command.FirstAirDate,
            EpisodeCount = command.EpisodeCount,
            AverageEpisodeDuration = command.AverageEpisodeDuration,
            SeasonCount = command.SeasonCount,
            Rating = command.Rating,
            Title = command.Title,
            Status = command.Status,
            CategoryId = command.CategoryId
        });
        await _context.SaveChangesAsync();
    }
}