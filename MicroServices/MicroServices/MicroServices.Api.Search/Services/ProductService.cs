using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using MicroServices.Api.Search.Interfaces;
using MicroServices.Api.Search.Models;

namespace MicroServices.Api.Search.Services
{
    public class ProductService: IProductService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<(bool isSuccessful, IEnumerable<Product> products, string errorMessage)> GetAllProducts()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("ProductServices");
                var response = await client.GetAsync($"api/Products");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<IEnumerable<Product>>(content, options);
                    return (true, result, string.Empty);
                }
                return (true, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                return (true, null, "Not Found GetAppProducts Exception");
            }
        }
    }
}
