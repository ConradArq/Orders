using Microsoft.Ajax.Utilities;
using Microsoft.Extensions.Logging;
using ProyectoConrado.Data;
using ProyectoConrado.Extensions;
using ProyectoConrado.Logging.Extensions;
using ProyectoConrado.Services.Orders;
using ProyectoConrado.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace ProyectoConrado.Controllers
{
    [RoutePrefix("")]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IOrderDetailService orderDetailService;
        private readonly ILogger logger;

        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService, ILoggerFactory loggerFactory)
        {
            this.orderService = orderService;
            this.orderDetailService = orderDetailService;
            loggerFactory.AddFile(System.Configuration.ConfigurationManager.AppSettings["LogFilePath"]);
            logger = loggerFactory.CreateLogger<OrderController>();
        }

        public ActionResult Index()
        {
            return View();
        }

        [Route("ordenes")]
        public async Task<ActionResult> Order()
        {
            List<OrderViewModel> orderViewModels;
            try
            {
                var orders = await orderService.GetAllAsync();
                orderViewModels = orders.Select(o =>
                {
                    return (OrderViewModel)o.CopyPropertiesTo(new OrderViewModel());
                }).ToList();

                logger.Log(LogLevel.Information, "Acceso a base de datos para obtener todas las órdenes");
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, "Error al obtener órdenes de la base de datos");
                ViewBag.Error = "Error al obtener órdenes de la base de datos";
                orderViewModels = new List<OrderViewModel>();
            }

            return View(orderViewModels);
        }

        [Route("ordenes/{id}")]
        public async Task<ActionResult> OrderDetail([Bind(Prefix = "Id")] string orderId)
        {
            List<OrderDetailViewModel> orderDetailsViewModels;
            try
            {
                var orderDetails = await orderDetailService.GetByAsync(orderId);
                orderDetailsViewModels = orderDetails.Select(od =>
                {
                    return (OrderDetailViewModel)od.CopyPropertiesTo(new OrderDetailViewModel());

                }).ToList();

                logger.Log(LogLevel.Information, $"Acceso a base de datos para obtener detalle de la órden {orderId}");

            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, $"Error al obtener detalle de la órden {orderId} de la base de datos");
                ViewBag.Error = $"Error al obtener detalle de la órden {orderId} de la base de datos";
                orderDetailsViewModels = new List<OrderDetailViewModel>();
            }

            return View(orderDetailsViewModels);
        }
    }
}