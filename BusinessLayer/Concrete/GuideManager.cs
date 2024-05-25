using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

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
            throw new NotImplementedException();
        }

        public void Edit(Guide entity)
        {
            throw new NotImplementedException();
        }

        public List<Guide> GetAll()
        {
           return _guideDal.GetList();
        }

        public Guide GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guide entity)
        {
            throw new NotImplementedException();
        }
    }
}
