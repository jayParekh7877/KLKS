using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroServices.Api.Orders.Interfaces
{
    public interface IOrderProvider
    {

        Task<(bool isSuccessful, IEnumerable<Models.Order> orders, string errorMessage)> GetAllOrders(int customerId);
    }
}