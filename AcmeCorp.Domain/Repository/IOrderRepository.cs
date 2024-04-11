﻿using AcmeCorp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Domain.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersForCustomerAsync(int customerId);
        Task<Order> PlaceOrderForCustomerAsync(int customerId, Order order);
    }
}
