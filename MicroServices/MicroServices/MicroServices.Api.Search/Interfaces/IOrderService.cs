using System.Collections.Generic;
using System.Threading.Tasks;
using MicroServices.Api.Search.Models;

namespace MicroServices.Api.Search.Interfaces
{
    public interface IOrderService
    {
        Task<(bool isSuccesful, IEnumerable<Order> orders, string errorMessage)> GetOrder(int customerId);
    }
}