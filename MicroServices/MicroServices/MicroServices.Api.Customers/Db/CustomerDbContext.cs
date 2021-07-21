using Microsoft.EntityFrameworkCore;

namespace MicroServices.Api.Customers.Db
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}