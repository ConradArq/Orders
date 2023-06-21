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
    public class OrderDetailService: IOrderDetailService
    {
        private readonly IOrderDetailRepository orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            this.orderDetailRepository = orderDetailRepository;
        }

        public async Task<List<OrderDetail>> GetByAsync(string orderId)
        {
            return await orderDetailRepository.GetByAsync(orderId);
        }

        public Task<int> InsertOrUpdate(List<OrderDetail> orderDetails)
        {
            return orderDetailRepository.InsertOrUpdate(orderDetails);
        }

        public void Dispose()
        {
            orderDetailRepository.Dispose();
        }
    }
}