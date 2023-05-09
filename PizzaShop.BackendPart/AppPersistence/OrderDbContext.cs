using AppPersistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using ShopDomainLibrary;
using ShopApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence
{
    public class OrderDbContext:DbContext, IOrderDbContext
    {
        public DbSet<Order> Order { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
