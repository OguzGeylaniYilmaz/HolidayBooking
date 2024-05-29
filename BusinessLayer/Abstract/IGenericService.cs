using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
	public interface IGenericService<T>
    {
        void Add(T entity);
        void Remove(T entity);
        void Edit(T entity);
        List<T> GetAll();
        T GetById(int id);
      
    }
}
