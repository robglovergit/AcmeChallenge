using AcmeCorp.Domain.Entities;
using AcmeCorp.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Services.Services
{
    public class ContactInfoService
    {
        private readonly IContactInfoRepository _context;

        public ContactInfoService(IContactInfoRepository context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ContactInfo>> GetAllAsync()
        {
            return await _context.GetAllAsync();
        }

        public async Task<ContactInfo> GetByIdAsync(int id)
        {
            return await _context.GetByIdAsync(id);
        }

        public async Task AddAsync(ContactInfo contactInfo)
        {
            await _context.AddAsync(contactInfo);
        }

        public async Task UpdateAsync(ContactInfo contactInfo)
        {
            await _context.UpdateAsync(contactInfo);
        }

        public async Task DeleteAsync(int id)
        {
            var contactInfo = await _context.GetByIdAsync(id);
            if (contactInfo != null)
            {
                await _context.DeleteAsync(id);
            }
        }
    }
}
