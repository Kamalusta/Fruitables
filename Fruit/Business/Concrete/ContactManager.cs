using Business.Abstract;
using Business.Helpers.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager(IBaseRepository<Contact> contactDal) : IContactService
    {
        private readonly IBaseRepository<Contact> _contactDal = contactDal;

        public IResult Add(Contact contact)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Contact>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
