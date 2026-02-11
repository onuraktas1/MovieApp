using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.SeriesCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;

public class UpdateSeriesCommandHandler
{
    private readonly MovieContext _context;

    public UpdateSeriesCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateSeriesCommand command)
    {
        var series = await _context.Serieses.FindAsync(command.SeriesId);
        series.Title = command.Title;
        series.Description = command.Description;
        series.AverageEpisodeDuration = command.AverageEpisodeDuration;
        series.CoverImageUrl = command.CoverImageUrl;
        series.CreatedYear = command.CreatedYear;
        series.EpisodeCount = command.EpisodeCount;
        series.FirstAirDate = command.FirstAirDate;
        series.Status = command.Status;
        series.Rating = command.Rating;
        series.SeasonCount = command.SeasonCount;
        series.CategoryId = command.CategoryId;
        await _context.SaveChangesAsync();
    }
}