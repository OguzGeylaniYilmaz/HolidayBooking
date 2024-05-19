using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public List<T> GetList()
        {
            using var context = new Context();
            return context.Set<T>().ToList();
        }

        public void Delete(T entity)
        {
            using var context = new Context();
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public void Insert(T entity)
        {
            using var context = new Context();
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            using var context = new Context();
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }

        public T Get(int id)
        {
            using var context = new Context();
            return context.Set<T>().Find(id);
        }
    }
}
