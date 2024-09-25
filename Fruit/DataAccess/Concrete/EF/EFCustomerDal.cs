using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EF
{
    public class EFCustomerDal : BaseRepository<Customer, BaseProjectContext>, ICustomerDal
    {
        public Customer GetCustomerByMail(string email)
        {
            var context = new BaseProjectContext();

            var result = context.Customers.SingleOrDefault(c => c.Email == email);
            return (Customer)result;
        }
    }
}
