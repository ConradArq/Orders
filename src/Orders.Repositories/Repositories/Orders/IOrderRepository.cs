using ProyectoConrado.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConrado.Repositories.Repositories.Orders
{
    public interface IOrderRepository : IDisposable
    {
        Task<List<Order>> GetAllAsync();
        Task<int> InsertOrUpdate(List<Order> orders);
    }
}