using Business.Abstract;
using Business.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ContactManager(IBaseRepository<Contact> contactDal) : IContactService
    {
        private readonly IBaseRepository<Contact> _contactDal = contactDal;

        public IResult Add(Contact contact)
        {
            _contactDal.Add(contact);
            return new SuccessResult("Contact added");
        }

        public IResult Delete(int id)
        {
            Contact delContact = _contactDal.Get(c => c.Id == id);
            if (delContact != null)
                delContact.IsDelete = true;
            _contactDal.Delete(delContact);
            return new SuccessResult("Contact deleted");
        }

        public IDataResult<Contact> Get(int id)
        {
           var contact = _contactDal.Get(c => c.Id == id);
            if (contact != null)
                return new SuccessDataResult<Contact>(contact, "Contact loaded");
            else return new ErrorDataResult<Contact>(contact, "Contact not found");
        }

        public IResult Update(Contact contact)
        {
            Contact updatedContact = _contactDal.Get(c=>c.Id == contact.Id);
            updatedContact.Facebook = contact.Facebook;
            updatedContact.Address = contact.Address;
            updatedContact.Phone = contact.Phone;
            updatedContact.Email = contact.Email;
            updatedContact.Location = contact.Location;
            updatedContact.Sosial = contact.Sosial;
            updatedContact.IsDelete = contact.IsDelete;
            _contactDal.Update(contact);
            return new SuccessResult("Contact updated");
        }
    }
}
