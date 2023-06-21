using ProyectoConrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConrado.Repositories.Repositories.Orders
{
    public interface IOrderDetailRepository : IDisposable
    {
        Task<List<OrderDetail>> GetByAsync(string orderId);
        Task<int> InsertOrUpdate(List<OrderDetail> orderDetails);
    }
}