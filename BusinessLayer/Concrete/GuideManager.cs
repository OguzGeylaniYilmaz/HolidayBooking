using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class GuideManager : IGuideService
    {
        private readonly IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public void Add(Guide entity)
        {
            _guideDal.Insert(entity);
        }

        public void Edit(Guide entity)
        {
           _guideDal.Update(entity);
        }

        public List<Guide> GetAll()
        {
           return _guideDal.GetList();
        }

        public Guide GetById(int id)
        {
            return _guideDal.Get(id);
        }

        public void Remove(Guide entity)
        {
            throw new NotImplementedException();
        }
    }
}
