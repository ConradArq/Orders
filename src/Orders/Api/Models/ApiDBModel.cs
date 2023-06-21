using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoConrado.Api.Models
{
    public class ApiDBModel
    {
        [JsonProperty("ordenes")]
        public List<ApiDBOrder> ApiOrders { get; set; }

        [JsonProperty("detalles")]
        public List<ApiDBOrderDetail> ApiOrderDetails { get; set; }
    }

    public class ApiDBOrder
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("impuesto")]
        public string Tax { get; set; }

        [JsonProperty("subtotal")]
        public string Subtotal { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }
    }

    public class ApiDBOrderDetail
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nombre")]
        public string Name { get; set; }

        [JsonProperty("cantidad")]
        public string Quantity { get; set; }

        [JsonProperty("impuesto")]
        public string Tax { get; set; }

        [JsonProperty("precio")]
        public string Price { get; set; }

        [JsonProperty("subtotal")]
        public string Subtotal { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("ordenesId")]
        public string OrderId { get; set; }

    }
}