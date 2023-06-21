using ProyectoConrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConrado.Repositories.Repositories.Orders
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
    {
        public async Task<List<OrderDetail>> GetByAsync(string orderId)
        {
            IQueryable<OrderDetail> orderDetails = FindBy(o => o.Order.Id == orderId);
            return await orderDetails.ToListAsync();
        }

        public Task<int> InsertOrUpdate(List<OrderDetail> orderDetails)
        {
            foreach (OrderDetail od in orderDetails)
            {
                AddOrUpdate(od);
            }
            return SaveAsync();
        }
    }
}