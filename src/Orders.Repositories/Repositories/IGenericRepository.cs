using ProyectoConrado.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConrado.Repositories.Repositories.Orders
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        void Add(T entity);
        Task<int> SaveAsync();
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> where);
        PCContext GetContext();
    }
}