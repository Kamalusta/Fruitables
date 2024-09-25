using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class OrderDto : IDto
    {
        public string CustomerName { get; set; }
        public bool IsDifferentAddress { get; set; } = false;
        public string NewAddress { get; set; }
        public string OrderNote { get; set; }
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string ShippingMethod { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalOrderPrice { get; set; }
        public int ShippingId { get; set; }
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }

    }
}
