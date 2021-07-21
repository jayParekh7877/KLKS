using System.Threading.Tasks;
using MicroServices.Api.Products.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroServices.Api.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductProvider _productProvider;

        public ProductsController(IProductProvider productProvider)
        {
            _productProvider = productProvider;
        }

        [HttpGet]
        public async Task<ActionResult<Models.Product>> GetAllProducts()
        {
            var result = await _productProvider.GetAppProducts();
            if (result.isSuccesful)
            {
                return Ok(result.products);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _productProvider.GetProduct(id);
            if (result.isSuccessful)
            {
                return Ok(result.product);
            }
            else
            {
                return NotFound();
            }
        }
    }
}