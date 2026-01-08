using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

public class GetCategoryQueryHandler
{
    private readonly MovieContext _context;

    public GetCategoryQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<List<GetCategoryQueryResult>> Handle()
    {
        var result = await _context.Categories.ToListAsync();
        
        return result.Select(x => new GetCategoryQueryResult
        {
            CategoryId = x.CategoryId,
            CategoryName = x.CategoryName
        }).ToList();
    }
}