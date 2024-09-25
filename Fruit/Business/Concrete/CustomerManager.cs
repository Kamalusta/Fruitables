using Business.Abstract;
using Business.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager(ICustomerDal customerDal) : ICustomerService
    {
        private readonly ICustomerDal _customerDal = customerDal;
        public IResult Add(Customer customer)
        {
            var result = _customerDal.GetCustomerByMail(customer.Email);
            if (result == null)
            {
                _customerDal.Add(customer);
                return new SuccessResult("Customer added");
            }
            else return new ErrorResult("Email is already registered");
        }

        public IDataResult<Customer> GetByEmail(string email)
        {
            var result = _customerDal.GetCustomerByMail(email);
            if (result != null)
                return new SuccessDataResult<Customer>(result, "Customer Loaded");
            else return new ErrorDataResult<Customer>(result, "Customer not found");
        }
    }
}
