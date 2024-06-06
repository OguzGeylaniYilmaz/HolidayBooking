using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Traversal.UI.CQRS.Queries.GuideQueries;
using Traversal.UI.CQRS.Results.GuideResults;

namespace Traversal.UI.CQRS.Handlers.GuideHandlers
{
    public class GetGuidesQueryHandler : IRequestHandler<GetGuidesQuery,List<GetGuidesQueryResult>>
    {
        private readonly Context _context;

        public GetGuidesQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetGuidesQueryResult>> Handle(GetGuidesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x=>new GetGuidesQueryResult
            {
                GuideID = x.GuideID,
                Description = x.Description,
                Image = x.Image,
                Name = x.Name,
            }).AsNoTracking().ToListAsync();
        }
    }
}
