using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MicroServices.Api.Products.Db
{
    public class ProductsDbContexts : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductsDbContexts(DbContextOptions options) : base(options)
        {
        }
    }
}