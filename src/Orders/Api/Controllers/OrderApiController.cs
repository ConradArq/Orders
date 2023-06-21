using Microsoft.Extensions.Logging;
using ProyectoConrado.Api.Helpers;
using ProyectoConrado.Api.Managers;
using ProyectoConrado.Api.Models;
using ProyectoConrado.Controllers;
using ProyectoConrado.Core.Models;
using ProyectoConrado.Extensions;
using ProyectoConrado.Logging.Extensions;
using ProyectoConrado.Repositories.Repositories.Orders;
using ProyectoConrado.Services.Orders;
using ProyectoConrado.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;

namespace ProyectoConrado.Api.Controllers
{
    [RoutePrefix("api/Order")]
    public class OrderApiController : ApiController
    {

        private readonly ILogger logger;

        public OrderApiController()
        {
            LoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddFile(System.Configuration.ConfigurationManager.AppSettings["LogFilePath"]);
            logger = loggerFactory.CreateLogger<OrderApiController>();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<HttpResponseMessage> Get()
        {
            ApiDBManager apiDBManager = new ApiDBManager(logger);
            ApiDBModel apiDbModel = await apiDBManager.CreateIfNotExistAndFillDB();

            if (apiDbModel == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Error al obtener órdenes de la api y guardar en la base de datos");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, apiDbModel.ApiOrders.OrderBy(o => o.Id), "application/json");
            }
        }
    }
}