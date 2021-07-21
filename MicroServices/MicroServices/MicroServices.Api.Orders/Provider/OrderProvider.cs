using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MicroServices.Api.Orders.Db;
using MicroServices.Api.Orders.Interfaces;
using Microsoft.EntityFrameworkCore;
using Order = MicroServices.Api.Orders.Models.Order;

namespace MicroServices.Api.Orders.Provider
{
    public class OrderProvider : IOrderProvider
    {
        private readonly OrderDbContexts _dbContexts;
        private readonly IMapper _mapper;

        public OrderProvider(OrderDbContexts dbContexts, IMapper mapper)
        {
            _dbContexts = dbContexts;
            _mapper = mapper;
            _dbContexts.Database.EnsureCreated();
            SeedData();
        }

        private void SeedData()
        {
            if (!_dbContexts.Orders.Any())
            {
                _dbContexts.OrderItems.Add(new OrderItem()
                    {Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 1});
                _dbContexts.OrderItems.Add(new OrderItem()
                    {Id = 2, OrderId = 1, ProductId = 2, Quantity = 2, UnitPrice = 2});
                _dbContexts.OrderItems.Add(new OrderItem()
                    {Id = 3, OrderId = 1, ProductId = 3, Quantity = 3, UnitPrice = 3});
                _dbContexts.OrderItems.Add(new OrderItem()
                    {Id = 4, OrderId = 2, ProductId = 4, Quantity = 4, UnitPrice = 4});

                _dbContexts.SaveChanges();

                var orderItem1 = _dbContexts.OrderItems.Where(o => o.OrderId == 1).ToList();
                var orderItem2 = _dbContexts.OrderItems.Where(o => o.OrderId == 2).ToList();

                _dbContexts.Orders.Add(new Db.Order()
                {
                    CustomerId = 1, Id = 1, OrderDateTime = DateTime.Today, Total = 100,
                    Items = orderItem1
                });
                _dbContexts.Orders.Add(new Db.Order()
                {
                    CustomerId = 1,
                    Id = 2,
                    OrderDateTime = DateTime.Today,
                    Total = 200,
                    Items = orderItem2
                });
                _dbContexts.SaveChanges();
            }
        }

        public async Task<(bool isSuccessful, IEnumerable<Order> orders, string errorMessage)> GetAllOrders(
            int customerId)
        {
            try
            {
                var orders = 
                    _dbContexts.Orders.Where(x => x.CustomerId == customerId)
                        .Include(o => o.Items);
                if (orders != null && orders.Any())
                {
                    var result = _mapper.Map<IEnumerable<Db.Order>, IEnumerable<Models.Order>>(orders);
                    return (true, result, string.Empty);
                }

                return (false, null, "Not Found");
            }
            catch (Exception e)
            {
                return (false, null, "Not Found");
            }
        }
    }
}