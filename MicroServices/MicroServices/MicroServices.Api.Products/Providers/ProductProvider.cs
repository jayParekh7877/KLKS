using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MicroServices.Api.Products.Db;
using MicroServices.Api.Products.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Product = MicroServices.Api.Products.Models.Product;

namespace MicroServices.Api.Products.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly ILogger<ProductProvider> _logger;
        private readonly ProductsDbContexts _dbContexts;
        private readonly IMapper _mapper;

        public ProductProvider(ILogger<ProductProvider> logger, ProductsDbContexts dbContexts, IMapper mapper)
        {
            _logger = logger;
            _dbContexts = dbContexts;
            _mapper = mapper;
            SeedData();
            _dbContexts.Database.EnsureCreated();
        }

        private void SeedData()
        {
            if (_dbContexts.Products.Any()) return;
            _dbContexts.Products.Add(new Db.Product()
            {
                Id = 1,
                Inventory = 1,
                Name = "ABC",
                Price = 10,
            });
            _dbContexts.Products.Add(new Db.Product()
            {
                Id = 2,
                Inventory = 100,
                Name = "XYZ",
                Price = 20,
            });
            _dbContexts.Products.Add(new Db.Product()
            {
                Id = 3,
                Inventory = 300,
                Name = "PQR",
                Price = 30,
            });
            _dbContexts.SaveChangesAsync();
        }

        public async Task<(bool isSuccesful, IEnumerable<Models.Product> products, string errorMessage)>
            GetAppProducts()
        {
            try
            {
                var products = await _dbContexts.Products.ToListAsync();
                if (products != null && products.Any())
                {
                    var result = _mapper.Map<IEnumerable<Db.Product>, IEnumerable<Models.Product>>(products);
                    return (true, result, string.Empty);
                }

                return (false, null, "Not Found");
            }

            catch (Exception exception)
            {
                _logger?.LogError(exception.Message, exception);
                return (false, null, "Exception");
            }
        }

        public async Task<(bool isSuccessful, Product product, string errorMessage)> GetProduct(int id)
        {
            try
            {
                var product = await _dbContexts.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    var result = _mapper.Map<Db.Product, Models.Product>(product);
                    return (true, result, string.Empty);
                }

                return (false, null, "Product Not Found");
            }
            catch (Exception exception)
            {
                _logger?.LogError(exception.Message, exception);
                return (false, null, "Exception in GetProduct");
            }
        }
    }
}