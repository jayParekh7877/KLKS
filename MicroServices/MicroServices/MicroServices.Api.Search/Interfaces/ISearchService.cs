using System.Threading.Tasks;

namespace MicroServices.Api.Search.Interfaces
{
    public interface ISearchService
    {
        Task<(bool isSuccesfull, dynamic searchResult)> Search(int customerId);
    }
}