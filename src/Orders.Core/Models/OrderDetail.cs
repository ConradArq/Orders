using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConrado.Core.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Quantity { get; set; }

        public string Tax { get; set; }

        public string Price { get; set; }

        public string Subtotal { get; set; }

        public string Total { get; set; }

        public string OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}