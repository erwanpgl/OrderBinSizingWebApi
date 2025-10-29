using Microsoft.EntityFrameworkCore;
using OrderBinSizingWebApi.Domain.Models;
using System.Collections.Generic;

namespace OrderBinSizingWebApi.infrastructure
{
    public class AppDbContext: DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
