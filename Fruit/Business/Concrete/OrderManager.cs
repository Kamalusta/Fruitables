using Business.Abstract;
using Business.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager(IOrderDal orderDal) : IOrderService
    {
        private readonly IOrderDal _orderDal = orderDal;
        public IResult Add(Order order)
        {
            _orderDal.Add(order);
            return new SuccessResult("Order added");
        }

        public IResult Delete(int id)
        {
            Order delOrder =  _orderDal.Get(o=>o.Id == id);
            if (delOrder != null)
            {
                delOrder.IsDelete = true;
                _orderDal.Delete(delOrder);
                return new SuccessResult("Order deleted");
            }
            else return new ErrorResult("Order id not found");              
        }

        public IDataResult<List<OrderDto>> GetAllOrders()
        {
            var result = _orderDal.GetAllOrders();
            if (result.Count> 0)            
                return new SuccessDataResult<List<OrderDto>>(result, "Orders loaded");
            return new ErrorDataResult<List<OrderDto>>(result, "Orders not found");
        }

        public IResult Update(Order order)
        {
            Order updateOrder = _orderDal.Get(o=> o.Id == order.Id);
            if (updateOrder != null)
            {
               /* updateOrder.OrderNote = order.OrderNote;
                updateOrder.IsDifferentAddress = order.IsDifferentAddress;
                updateOrder.NewAddress = order.NewAddress;
                updateOrder.CustomerId = order.CustomerId;
                updateOrder.ShippingId = order.ShippingId;
                updateOrder.IsDelete = order.IsDelete;
                updateOrder.PaymentId = order.PaymentId;*/
                _orderDal.Update(order);
                return new SuccessResult("Order updated");
            }
            else return new ErrorResult("Order id not found");
        }
    }
}
