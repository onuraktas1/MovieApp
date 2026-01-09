using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class UpdateMovieCommandHandler
{
    private readonly MovieContext _context;

    public UpdateMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateMovieCommand command)
    {
        var movie = await _context.Movies.FindAsync(command.MovieId);
        movie.Title = command.Title;
        movie.Description = command.Description;
        movie.ReleaseDate = command.ReleaseDate;
        movie.CoverImageUrl = command.CoverImageUrl;
        movie.CreatedYear = command.CreatedYear;
        movie.Duration = command.Duration;
        movie.Status = command.Status;
        movie.Rating = command.Rating;
        await _context.SaveChangesAsync();
    }
}