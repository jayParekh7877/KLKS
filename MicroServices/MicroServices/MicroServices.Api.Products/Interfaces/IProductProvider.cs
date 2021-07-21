using System.Collections.Generic;
using System.Threading.Tasks;
using MicroServices.Api.Products.Models;

namespace MicroServices.Api.Products.Interfaces
{
    public interface IProductProvider
    {
        Task<(bool isSuccesful, IEnumerable<Product> products, string errorMessage)> GetAppProducts();
        Task<(bool isSuccessful, Models.Product product, string errorMessage)> GetProduct(int id);
    }
}