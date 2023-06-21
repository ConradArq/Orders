using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoConrado.Core.Models
{
    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        public string Tax { get; set; }

        public string Subtotal { get; set; }

        public string Total { get; set; }

        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}