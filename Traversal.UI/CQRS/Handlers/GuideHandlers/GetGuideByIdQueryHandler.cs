using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Traversal.UI.CQRS.Queries.GuideQueries;
using Traversal.UI.CQRS.Results.GuideResults;

namespace Traversal.UI.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIdQueryHandler : IRequestHandler<GetGuideByIdQuery, GetGuideByIdQueryResult>
    {
        private readonly DataAccessLayer.Concrete.Context _context;

        public GetGuideByIdQueryHandler(DataAccessLayer.Concrete.Context context)
        {
            _context = context;
        }

        public  async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
           var value = await _context.Guides.FindAsync(request.Id);
            return new GetGuideByIdQueryResult
            {
                Description = value.Description,
                GuideID = value.GuideID,
                Name = value.Name,
            };
        }
    }
}
