using Business.Abstract;
using Business.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager(IPaymentDal paymentDal) : IPaymentService
    {
        private readonly IPaymentDal _paymentDal = paymentDal;
        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult("Payment method added");
        }

        public IResult Delete(int id)
        {
            Payment result = _paymentDal.Get(p=>p.Id == id);
            if (result != null)
            {
                result.IsDelete = true;
                _paymentDal.Delete(result);
                return new SuccessResult("Payment method deleted");
            }
            return new ErrorResult("Payment method not found");
        }

        public IDataResult<List<Payment>> GetAll()
        {
            var result =  _paymentDal.GetAll(p => p.IsDelete == false).ToList();
            if (result.Count > 0)            
                return new SuccessDataResult<List<Payment>>(result,"Payment methods loaded");
            else return new ErrorDataResult<List<Payment>>(result, "Payment methods not found");
            
        }

        public IResult Update(Payment payment)
        {
            Payment result = _paymentDal.Get(p => p.Id == payment.Id);
            if (result != null)
            {                
                _paymentDal.Delete(payment);
                return new SuccessResult("Payment method updated");
            }
            return new ErrorResult("Payment method not found");
        }
    }
}
