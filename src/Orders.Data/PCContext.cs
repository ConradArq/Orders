using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoConrado.Data
{
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.Entity.Validation;
    using ProyectoConrado.Core.Models;
    using System.Data.Entity.Infrastructure;
    using System;
    using System.Threading;
    using System.Data.Entity.Migrations;

    public partial class PCContext : DbContext
    {

        public int UserID { get; set; }

        public PCContext()
            : base("name=PCContext")
        {
            //Database.CreateIfNotExists();
            //Database.SetInitializer<PCContext>(new PCDBInitializer());           
        }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetail)
                .WithRequired(o => o.Order)
                .WillCascadeOnDelete(false);
        }
    }

    //public class PCDBInitializer : CreateDatabaseIfNotExists<PCContext>
    //{
    //    protected override void Seed(PCContext context)
    //    {
    //        context.Order.AddOrUpdate(o => o.Id,
    //            new Order() { Id = "963639d4-131b-42b6-96c5-c52fa40bcd49", Tax = "156.19", Subtotal = "2231.04", Total = "2387.23" },
    //            new Order() { Id = "34444-131b-42b6-96c5-c52fa40bcd49", Tax = "156.19", Subtotal = "2231.04", Total = "2387.23" },
    //            new Order() { Id = "777-131b-42b6-96c5-c52fa40bcd49", Tax = "156.19", Subtotal = "2231.04", Total = "2387.23" }
    //        );
    //    }
    //}
}