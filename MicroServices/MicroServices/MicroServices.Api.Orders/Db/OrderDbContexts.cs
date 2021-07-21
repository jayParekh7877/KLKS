using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MicroServices.Api.Orders.Db
{
    public class OrderDbContexts : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public OrderDbContexts(DbContextOptions options) : base(options)
        {
        }
    }
}