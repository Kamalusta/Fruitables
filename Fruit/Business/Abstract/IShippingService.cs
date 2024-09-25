using Business.Helpers.Results.Abstract;
using Business.Helpers.Results.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IShippingService
    {
        IResult Add(Shipping shipping);
        IResult Update(Shipping shipping);
        IResult Delete(int id);
        IDataResult<List<Shipping>> GetAll();
    }
}
