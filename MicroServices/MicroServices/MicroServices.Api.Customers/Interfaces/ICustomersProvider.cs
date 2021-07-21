using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroServices.Api.Customers.Interfaces
{
    public interface ICustomersProvider
    {
        Task<(bool isSuccesful, IEnumerable<Models.Customer> customers, string errorMessage)> GetAllCustomers();
        Task<(bool isSuccesful, Models.Customer customer, string errorMessage)> GetCustomer(int id);
    }
}