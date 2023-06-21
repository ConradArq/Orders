using ProyectoConrado.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConrado.Repositories.Repositories.Orders
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {

        private PCContext dbContext = new PCContext();
        public PCContext Context
        {
            get { return dbContext; }
            set { dbContext = value; }
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = dbContext.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = dbContext.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Added;
        }

        public virtual void AddOrUpdate(T entity)
        {
            dbContext.Set<T>().AddOrUpdate(entity);
        }

        public virtual void AddRange(IEnumerable<T> entity)
        {
            dbContext.Set<T>().AddRange(entity);
        }


        public virtual Task<int> SaveAsync()
        {
            return dbContext.SaveChangesAsync();
        }

        public virtual void Dispose()
        {
            dbContext.Dispose();
        }

        public PCContext GetContext()
        {
            return Context;
        }

    }
}