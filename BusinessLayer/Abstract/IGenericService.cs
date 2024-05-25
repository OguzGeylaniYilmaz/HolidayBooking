using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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
