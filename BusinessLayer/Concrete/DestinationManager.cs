using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
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
            _destinationDal.Insert(entity);
        }

        public void Edit(Destination entity)
        {
            _destinationDal.Update(entity);
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
            _destinationDal.Delete(entity);
        }
    }
}
