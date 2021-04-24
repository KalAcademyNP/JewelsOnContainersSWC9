using Microsoft.EntityFrameworkCore;
using OrderApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Data
{
    public class OrdersContext : DbContext
    {
        public OrdersContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(e =>
            {
                e.Property(o => o.OrderId)
                    .IsRequired()
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<OrderItem>(e =>
            {
                e.Property(o => o.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.HasOne(o => o.Order)
                    .WithMany()
                    .HasForeignKey(o => o.OrderId);
            });


        }
    }
}
