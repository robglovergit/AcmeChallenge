﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public string Address { get; set; }

        public ICollection<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
