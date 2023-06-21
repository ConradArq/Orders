using ProyectoConrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConrado.Services.Orders
{
    public interface IOrderService : IDisposable
    {
        Task<List<Order>> GetAllAsync();
        Task<int> InsertOrUpdate(List<Order> orders);
    }
}