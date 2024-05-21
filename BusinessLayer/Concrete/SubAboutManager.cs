using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class SubAboutManager : ISubAboutService
    {
        private readonly ISubAboutDal _subAboutDal;

        public SubAboutManager(ISubAboutDal subAboutDal)
        {
            _subAboutDal = subAboutDal;
        }

        public void Add(SubAbout entity)
        {
           _subAboutDal.Insert(entity);
        }

        public void Edit(SubAbout entity)
        {
            _subAboutDal.Update(entity);
        }

        public List<SubAbout> GetAll()
        {
            return _subAboutDal.GetList();
        }

        public SubAbout GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(SubAbout entity)
        {
            throw new NotImplementedException();
        }
    }
}
