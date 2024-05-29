using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void Add(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(AppUser entity)
        {
            _appUserDal.Update(entity);
        }

        public List<AppUser> GetAll()
        {
            return _appUserDal.GetList();
        }

        public AppUser GetById(int id)
        {
            return _appUserDal.Get(id);
        }

        public void Remove(AppUser entity)
        {
            _appUserDal.Delete(entity);
        }
    }
}
