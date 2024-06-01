using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Traversal.UI.CQRS.Results.DestinationResult;

namespace Traversal.UI.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationsQueryHandler
    {
        private readonly Context _context;

        public GetDestinationsQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetDestinationsQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetDestinationsQueryResult
            {
                id = x.DestinationID,
                capacity = x.Capacity,
                city = x.City,
                daynight = x.DayNight,
                price = x.Price
            }).AsNoTracking().ToList();

            return values;
        }
    }
}
