using AcmeCorp.Domain.Entities;
using AcmeCorp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Services.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository; 

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersForCustomerAsync(int customerId)
        {
            return await _orderRepository.GetAllOrdersForCustomerAsync(customerId);
        }

        public async Task<Order> PlaceOrderForCustomerAsync(int customerId, Order order)
        {
            order.CustomerId = customerId; 
            await _orderRepository.PlaceOrderForCustomerAsync(customerId, order);
            return order;
        }

    }
}
