using MediatR;
using Traversal.UI.CQRS.Results.GuideResults;

namespace Traversal.UI.CQRS.Queries.GuideQueries
{
    public class GetGuideByIdQuery : IRequest<GetGuideByIdQueryResult>
    {
        public int Id { get; set; }

        public GetGuideByIdQuery(int id)
        {
            Id = id;
        }
    }
}
