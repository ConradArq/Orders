using ProyectoConrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConrado.Services.Orders
{
    public interface IOrderDetailService : IDisposable
    {
        Task<List<OrderDetail>> GetByAsync(string orderId);
        Task<int> InsertOrUpdate(List<OrderDetail> orderDetails);
    }
}