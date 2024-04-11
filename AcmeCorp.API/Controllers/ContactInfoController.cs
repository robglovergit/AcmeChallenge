using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcmeCorp.API.Data;
using AcmeCorp.Domain.Entities;
using AcmeCorp.Domain.Repository;

namespace AcmeCorp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactInfoRepository _contactInfoService;

        public ContactInfoController(IContactInfoRepository context)
        {
            _contactInfoService = context;
        }

        /// <summary>
        /// Retrieves all contact information entries for a specified customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer whose contact information is to be retrieved.</param>
        /// <returns>A list of contact information entries for the specified customer.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ContactInfo>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAllContactInfoForCustomer(int customerId)
        {
            var contactInfos = await _contactInfoService.GetByIdAsync(customerId);
            if (contactInfos == null)
            {
                return NotFound($"No contact info found for customer with ID {customerId}.");
            }
            return Ok(contactInfos);
        }

        /// <summary>
        /// Adds a new contact information entry for a specified customer.
        /// </summary>
        /// <param name="customerId">The ID of the customer for whom the contact information is being added.</param>
        /// <param name="contactInfo">The contact information to add.</param>
        /// <returns>The created contact information entry.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ContactInfo), 201)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> AddContactInfoForCustomer(int customerId, ContactInfo contactInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedContactInfo = await _contactInfoService.AddAsync(contactInfo);
            return CreatedAtAction(nameof(GetAllContactInfoForCustomer), new { customerId = customerId }, addedContactInfo);
        }
    }
}
