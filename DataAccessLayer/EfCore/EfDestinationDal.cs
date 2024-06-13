using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccessLayer.EfCore
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public Destination GetDestinationWithGuide(int id)
        {
            using (var context = new Context())
            {
                return context.Destinations.Where(x => x.DestinationID == id).Include(y => y.Guide).FirstOrDefault();
            }
        }
    }
}
