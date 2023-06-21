using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoConrado.ViewModels
{
    public class OrderDetailViewModel
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

    }
}