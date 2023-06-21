using ProyectoConrado.Core.Models;
using ProyectoConrado.Repositories.Repositories;
using ProyectoConrado.Repositories.Repositories.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConrado.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;

        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await orderRepository.GetAllAsync();
        }

        public Task<int> InsertOrUpdate(List<Order> orders)
        {
            return orderRepository.InsertOrUpdate(orders);
        }

        public void Dispose()
        {
            orderRepository.Dispose();
        }
    }
}
