using Business.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserCommentService
    {
        IResult Add(UserComment userComment);
        IResult Update(UserComment userComment);
        IResult Delete(int id);
        IDataResult<List<UserComment>> GetAll();
    }
}
