using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

public class GetCategoryByIdQueryHandler
{
    private readonly MovieContext _context;

    public GetCategoryByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
    {
        var result = await _context.Categories.FindAsync(query.CategoryId);
        return new GetCategoryByIdQueryResult
        {
            CategoryId = result.CategoryId,
            CategoryName = result.CategoryName,
        };
    }
}