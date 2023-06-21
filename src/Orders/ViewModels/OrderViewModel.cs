using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoConrado.ViewModels
{
    public class OrderViewModel
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
}