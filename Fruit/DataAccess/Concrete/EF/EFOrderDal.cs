using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class EfOrderDal : BaseRepository<Order, BaseProjectContext>, IOrderDal
    {
        public List<OrderDto> GetAllOrders()
        {
            var context = new BaseProjectContext();
            var result = from o in context.Orders
                         where o.IsDelete == false
                         join c in context.Customers on o.CustomerId equals c.Id
                         join py in context.Payments on o.PaymentId equals py.Id
                         join sh in context.Shippings on o.ShippingId equals sh.Id
                         select new OrderDto
                         {
                             CustomerName = c.FirstName,
                             IsDifferentAddress = o.IsDifferentAddress,
                             NewAddress = o.NewAddress,
                             OrderNote = o.OrderNote,
                             Date = o.Date,
                             ShippingMethod = sh.Type,
                             PaymentMethod = py.Type,
                             TotalOrderPrice = o.TotalOrderPrice,
                             ShippingId = sh.Id,
                             PaymentId = py.Id,
                             CustomerId = c.Id
                         };
            return result.ToList();


        }
    }
}
