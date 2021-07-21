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
    public class OrderService : IOrderService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<(bool isSuccesful, IEnumerable<Order> orders, string errorMessage)> GetOrder(int customerId)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("OrderServices");
                var response = await client.GetAsync($"api/Orders/{customerId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsByteArrayAsync();
                    var options = new JsonSerializerOptions() {PropertyNameCaseInsensitive = true};
                    var result = JsonSerializer.Deserialize<IEnumerable<Order>>(content, options);
                    return (true, result, string.Empty);
                }
                return (true, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                return (true, null, "Not Found GetOrder Exception");
            }
        }
    }
}
