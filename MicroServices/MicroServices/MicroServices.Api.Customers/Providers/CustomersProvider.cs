using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MicroServices.Api.Customers.Db;
using MicroServices.Api.Customers.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Customer = MicroServices.Api.Customers.Models.Customer;

namespace MicroServices.Api.Customers.Providers
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly CustomerDbContext _dbContext;
        private readonly ILogger<CustomersProvider> _logger;
        private readonly IMapper _mapper;

        public CustomersProvider(CustomerDbContext dbContext, ILogger<CustomersProvider> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger;
            _mapper = mapper;
            dbContext.Database.EnsureCreated();
            SeedData();
        }

        private void SeedData()
        {
            if (!_dbContext.Customers.Any())
            {
                _dbContext.Customers.Add(new Db.Customer() {Address = "Address1", Id = 1, Name = "Name1"});
                _dbContext.Customers.Add(new Db.Customer() {Address = "Address2", Id = 2, Name = "Name2"});
                _dbContext.Customers.Add(new Db.Customer() {Address = "Address3", Id = 3, Name = "Name3"});
                _dbContext.Customers.Add(new Db.Customer() {Address = "Address4", Id = 4, Name = "Name4"});
                _dbContext.Customers.Add(new Db.Customer() {Address = "Address5", Id = 5, Name = "Name5"});
            }

            _dbContext.SaveChanges();
        }

        public async Task<(bool isSuccesful, IEnumerable<Customer> customers, string errorMessage)> GetAllCustomers()
        {
            try
            {
                var customers = await _dbContext.Customers.ToListAsync();
                if (customers != null && customers.Any())
                {
                    var result = _mapper.Map<IEnumerable<Db.Customer>, IEnumerable<Models.Customer>>(customers);
                    return (true, result, string.Empty);
                }
            }
            catch (Exception exception)
            {
                _logger?.LogError("Exception in GetAllCustomers", exception);
                return (false, null, "Exception in GetAllCustomers");
            }

            return (false, null, "Exception in GetAllCustomers");
        }

        public async Task<(bool isSuccesful, Customer customer, string errorMessage)> GetCustomer(int id)
        {
            try
            {
                var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
                if (customer != null)
                {
                    var result = _mapper.Map<Db.Customer, Models.Customer>(customer);
                    return (true, result, string.Empty);
                }
            }
            catch (Exception exception)
            {
                _logger?.LogError("Exception in GetCustomer", exception);
                return (false, null, "Exception in GetCustomer");
            }

            return (false, null, "Exception in GetCustomer");
        }
    }
}