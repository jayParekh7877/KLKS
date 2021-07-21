using System.Threading.Tasks;
using MicroServices.Api.Customers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroServices.Api.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersProvider _customersProvider;

        public CustomerController(ICustomersProvider customersProvider)
        {
            _customersProvider = customersProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _customersProvider.GetAllCustomers();
            if (result.isSuccesful)
            {
                return Ok(result.customers);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var result = await _customersProvider.GetCustomer(id);
            if (result.isSuccesful)
            {
                return Ok(result.customer);
            }
            else
            {
                return NotFound();
            }
        }
    }
}