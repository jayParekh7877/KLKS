using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroServices.Api.Orders.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroServices.Api.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderProvider _orderProvider;

        public OrdersController(IOrderProvider orderProvider)
        {
            _orderProvider = orderProvider;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOrders(int id)
        {
            var result = await _orderProvider.GetAllOrders(id);
            if (result.isSuccessful)
            {
                return Ok(result.orders);
            }
            else
            {
                return NotFound();
            }
        }
    }
}