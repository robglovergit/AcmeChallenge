using AcmeCorp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Domain.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);
        Task<List<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
        // Define other necessary methods
    }
}
