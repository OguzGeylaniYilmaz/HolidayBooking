using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void Add(Feature entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Feature entity)
        {
            throw new NotImplementedException();
        }

        public List<Feature> GetAll()
        {
            return _featureDal.GetList();
        }

        public Feature GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Feature entity)
        {
            _featureDal.Delete(entity);
        }
    }
}
