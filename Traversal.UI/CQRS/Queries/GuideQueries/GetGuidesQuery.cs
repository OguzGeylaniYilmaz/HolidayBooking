using MediatR;
using System.Collections.Generic;
using Traversal.UI.CQRS.Results.GuideResults;

namespace Traversal.UI.CQRS.Queries.GuideQueries
{
    public class GetGuidesQuery : IRequest<List<GetGuidesQueryResult>>
    {

    }
}
