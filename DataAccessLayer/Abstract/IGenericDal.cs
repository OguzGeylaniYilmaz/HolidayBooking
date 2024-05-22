using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
    {
        List<T> GetList();
        List<T> GetListByFilter(Expression<Func<T, bool>> predicate);
        T Get(int id);
        void Delete(T entity);
        void Update(T entity);
        void Insert(T entity);
    }
}
