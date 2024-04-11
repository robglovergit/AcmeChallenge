using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } 
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
