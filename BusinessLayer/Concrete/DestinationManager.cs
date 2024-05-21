using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {
        private readonly IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public void Add(Destination entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Destination entity)
        {
            throw new NotImplementedException();
        }

        public List<Destination> GetAll()
        {
           return _destinationDal.GetList();
        }

        public Destination GetById(int id)
        {
            return _destinationDal.Get(id);
        }

        public void Remove(Destination entity)
        {
            throw new NotImplementedException();
        }
    }
}
