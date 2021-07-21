using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServices.Api.Search.Interfaces;
using MicroServices.Api.Search.Models;

namespace MicroServices.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrderService _orderService;

        public SearchService(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<(bool isSuccesfull, dynamic searchResult)> Search(int customerId)
        {
            var orderResult = await _orderService.GetOrder(customerId);
            if (orderResult.isSuccesful)
            {
                var result = new
                {
                    Order = orderResult.orders
                };
                return (true, result);
            }

            return (false, null);
        }
    }
}