using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
    {
        List<T> GetList();
        T Get(int id);
        void Delete(T entity);
        void Update(T entity);
        void Insert(T entity);
    }
}
