using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EfCore
{
    public class EfSubAboutDal : GenericRepository<SubAbout>, ISubAboutDal
    {
    }
}
