using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Add(About entity)
        {
           _aboutDal.Insert(entity);
        }

        public void Edit(About entity)
        {
           _aboutDal.Update(entity);
        }

        public List<About> GetAll()
        {
            return _aboutDal.GetList();
        }

        public About GetById(int id)
        {
           return _aboutDal.Get(id);
        }

        public void Remove(About entity)
        {
            _aboutDal.Delete(entity);
        }
    }
}
