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
        private readonly IProductService _productService;

        public SearchService(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        public async Task<(bool isSuccesfull, dynamic searchResult)> Search(int customerId)
        {
            var orderResult = await _orderService.GetOrder(customerId);
            if (orderResult.isSuccesful)
            {
                var productResult = await _productService.GetAllProducts();
                if (productResult.isSuccessful)
                {
                    foreach (var order in orderResult.orders)
                    {
                        foreach (var orderItem in order.Items)
                        {
                            var productName = productResult.products.FirstOrDefault(p => p.Id == orderItem.ProductId)
                                ?.Name;
                            orderItem.ProductName = productName;
                        }
                    }
                }

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