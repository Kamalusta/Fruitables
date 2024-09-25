using Business.Abstract;
using Business.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ShippingManager : IShippingService
    {
        private readonly IShippingDal _shippingDal;
        public ShippingManager(IShippingDal shippingDal)
        {
            _shippingDal = shippingDal;
        }

        public IResult Add(Shipping shipping)
        {
            _shippingDal.Add(shipping);
            return new SuccessResult("Shipping method added");
        }

        public IResult Delete(int id)
        {
            Shipping result = _shippingDal.Get(s => s.Id == id);
            if (result != null)
            {
                result.IsDelete = true;
                _shippingDal.Delete(result);
                return new SuccessResult("Shipping method deleted");
            }
            return new ErrorResult("Shipping method not found");
        }

        public IDataResult<List<Shipping>> GetAll()
        {
            var result = _shippingDal.GetAll(s => s.IsDelete == false).ToList();
            if (result.Count > 0)
                return new SuccessDataResult<List<Shipping>>(result, "Shipping methods loaded");
            else return new ErrorDataResult<List<Shipping>>(result, "Shipping methods not found");
        }

        public IResult Update(Shipping shipping)
        {

            Shipping result = _shippingDal.Get(s => s.Id == shipping.Id);
            if (result != null)
            {
                _shippingDal.Delete(shipping);
                return new SuccessResult("Shipping method updated");
            }
            return new ErrorResult("Shipping method not found");
        }
    }
}
