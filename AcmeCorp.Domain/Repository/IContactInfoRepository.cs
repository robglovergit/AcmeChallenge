using AcmeCorp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Domain.Repository
{
    public interface IContactInfoRepository
    {
        /// <summary>
        /// Retrieves all contact information asynchronously.
        /// </summary>
        /// <returns>A task representing an asynchronous operation containing a list of all contact information.</returns>
        Task<IEnumerable<ContactInfo>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific contact information by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the contact information to retrieve.</param>
        /// <returns>A task representing an asynchronous operation containing the requested contact information.</returns>
        Task<ContactInfo> GetByIdAsync(int id);

        /// <summary>
        /// Adds new contact information asynchronously.
        /// </summary>
        /// <param name="contactInfo">The contact information to add.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task <ContactInfo> AddAsync(ContactInfo contactInfo);

        /// <summary>
        /// Updates existing contact information asynchronously.
        /// </summary>
        /// <param name="contactInfo">The contact information to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task UpdateAsync(ContactInfo contactInfo);

        /// <summary>
        /// Deletes contact information by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the contact information to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync(int id);
    }
}
