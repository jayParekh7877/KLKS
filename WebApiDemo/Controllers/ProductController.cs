using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDemo.Models;
using WebApiDemo.Parameters;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // validates inout data types 
    public class ProductController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductController(ShopContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        //[HttpGet]
        //public IEnumerable<Product> GetAllProduct()
        //{
        //    return _context.Products.ToArray();
        //}

        //[HttpGet]
        //public IActionResult GetAllProduct()
        //{
        //    return Ok(_context.Products.ToArray());
        //}


        //[HttpGet("{id}")]
        ////[HttpGet, Route("api/[controller]/{id}")] not working TODO
        //public IActionResult GetProduct(int id)
        //{
        //    var product = _context.Products.Find(id);
        //    return Ok(product);
        //}

        //Not Found Example returns 404
        //[HttpGet("{id:int}")]
        //public IActionResult GetProductNotFound(int id)
        //{
        //    var product = _context.Products.Find(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(product);
        //}

        //Async Await example
        [HttpGet("{id}")]
        //[HttpGet("{id?}")] ? to make optional
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery] QueryParameters parameters)
        {
            IQueryable<Product> products = _context.Products;
            var result = await products.Skip(parameters.Size * (parameters.Page - 1))
                .Take(parameters.Size).ToArrayAsync();
            //Skip : to skip number of pages, skip 5 to reach 6
            //Take : for size of records
            // Example query : https://localhost:44328/api/Product?size=13&page=2
            // ? start adding queryParameters
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetProduct", new {id = product.Id}, product);
            //return Created($"api/Products/{product.Id}", product);
        }
    }
}