using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sample.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Edit(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(Guid id);
        T GetSingle(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);
        IQueryable<T> AsQueryable();
        IQueryable<T> AsQueryable(bool readOnly);
    }
}
