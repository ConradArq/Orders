using ProyectoConrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConrado.Repositories.Repositories.Orders
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public async Task<List<Order>> GetAllAsync() 
        {
            IQueryable<Order> orders = GetAll();
            return await orders.ToListAsync();
        }

        public Task<int> InsertOrUpdate(List<Order> orders)
        {   
            foreach(Order o in orders)
            {
                AddOrUpdate(o);
            }
            return SaveAsync();
        }
    }
}