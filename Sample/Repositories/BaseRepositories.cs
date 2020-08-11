using Microsoft.EntityFrameworkCore;
using Sample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sample.Repositories
{

    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : class
    {
        private readonly DbSet<T> dbSet;

        public DbContext Context { get; private set; }

        public BaseRepository(DbContext dbContext)
        {
            Context = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public T Add(T entity)
        {
            T addedEntity = dbSet.Add(entity).Entity;

            return addedEntity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbSet.AddRange(entities);
        }

        public void Edit(T entity)
        {
            dbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
            {
                dbSet.Remove(obj);
            }
        }

        public T GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        public T GetSingle(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = GetAll();

            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where);
        }

        public bool IsExist(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Any(predicate);
        }

        public IQueryable<T> AsQueryable()
        {
            return dbSet.AsTracking();
        }

        public IQueryable<T> AsQueryable(bool readOnly)
        {
            return readOnly ? dbSet.AsNoTracking() : dbSet.AsTracking();
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }
    }
}
