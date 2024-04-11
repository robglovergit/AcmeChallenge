using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcmeCorp.API.Data;
using AcmeCorp.Domain.Entities;
using static NuGet.Packaging.PackagingConstants;
using AcmeCorp.Domain.Repository;

namespace AcmeCorp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderService;

        public OrdersController(IOrderRepository orderService)
        {
            _orderService = orderService;
        }


        /// <summary>
        /// Retrieves all orders placed by a specified customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer whose orders are to be retrieved.</param>
        /// <returns>A list of orders placed by the specified customer.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Order>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllOrdersForCustomer(int customerId)
        {
            var orders = await _orderService.GetAllOrdersForCustomerAsync(customerId);
            if (orders == null)
            {
                return NotFound($"No orders found for customer with ID {customerId}.");
            }
            return Ok(orders);
        }

        /// <summary>
        /// Places a new order for a specified customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer placing the order.</param>
        /// <param name="order">The order details.</param>
        /// <returns>The details of the placed order.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Order), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> PlaceOrderForCustomer(int customerId, [FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var placedOrder = await _orderService.PlaceOrderForCustomerAsync(customerId, order);
            return CreatedAtAction(nameof(GetAllOrdersForCustomer), new { customerId = customerId }, placedOrder);
        }
    }
}
