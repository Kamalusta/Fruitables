using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }
        public bool IsDifferentAddress { get; set; } = false;
        public string NewAddress { get; set; }
        public string OrderNote { get; set; }
        public DateOnly Date { get; set; }
        public int ShippingId { get; set; }
        public int PaymentId { get; set; }

    }
}
