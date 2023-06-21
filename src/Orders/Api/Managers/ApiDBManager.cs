using Microsoft.Extensions.Logging;
using ProyectoConrado.Api.Controllers;
using ProyectoConrado.Api.Helpers;
using ProyectoConrado.Api.Models;
using ProyectoConrado.Core.Models;
using ProyectoConrado.Extensions;
using ProyectoConrado.Logging.Extensions;
using ProyectoConrado.Repositories.Repositories.Orders;
using ProyectoConrado.Services.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace ProyectoConrado.Api.Managers
{
    public class ApiDBManager
    {
        private readonly ILogger logger;
        public ApiDBManager(ILogger logger)
        {
            this.logger = logger;
        }

        public async Task<ApiDBModel> CreateIfNotExistAndFillDB()
        {

            OrderService orderService = new OrderService(new OrderRepository());
            OrderDetailService orderDetailService = new OrderDetailService(new OrderDetailRepository());

            try
            {
                string dBApiUrl = System.Configuration.ConfigurationManager.AppSettings["DBApiEndpoint"];
                string dbJson = await ApiHelper.GetJsonAsync(dBApiUrl);

                logger.Log(LogLevel.Information, "Recuperación de datos de la Api ");

                ApiDBModel apiDBModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiDBModel>(dbJson);

                List<Order> orders = apiDBModel.ApiOrders.Select(o =>
                {
                    return (Order)o.CopyPropertiesTo(new Order());
                }
                ).ToList();

                int orderState = await orderService.InsertOrUpdate(orders);

                List<OrderDetail> orderDetails = apiDBModel.ApiOrderDetails.Select(od =>
                {
                    return (OrderDetail)od.CopyPropertiesTo(new OrderDetail());
                }
                ).ToList();

                int orderDetailState = await orderDetailService.InsertOrUpdate(orderDetails);

                logger.Log(LogLevel.Information, "Guardado o actualización de las órdenes y sus detalles en la base de datos");

                return apiDBModel;

            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, "Error al obtener datos de la api o actualizar la base de datos");
                return null;

            }
            finally
            {
                orderService.Dispose();
                orderDetailService.Dispose();
            }

        }
    }
}