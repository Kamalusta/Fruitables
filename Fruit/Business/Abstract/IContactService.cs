﻿using Business.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        IResult Add(Contact contact);
        IResult Update(Contact contact);
        IResult Delete(int id);
        IDataResult<List<Contact>> GetAllCategories();
    }
}
