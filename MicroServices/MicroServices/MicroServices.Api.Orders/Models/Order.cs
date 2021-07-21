using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServices.Api.Orders.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public int Total { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
    }
}
