using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroServices.Api.Search.Interfaces
{
    public interface IProductService
    {
        Task<(bool isSuccessful, IEnumerable<Models.Product> products, string errorMessage)> GetAllProducts();
    }
}