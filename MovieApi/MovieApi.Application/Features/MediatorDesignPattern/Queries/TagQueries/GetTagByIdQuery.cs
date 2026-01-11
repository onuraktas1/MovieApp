using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;

public class GetTagByIdQuery : IRequest<GetTagByIdQueryResult>
{
    public GetTagByIdQuery(int id)
    {
        TagId = id;
    }

    public int TagId { get; set; }
}