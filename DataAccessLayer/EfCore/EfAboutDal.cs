using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EfCore
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
    }
}
