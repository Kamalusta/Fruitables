using Business.Abstract;
using Business.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserCommentManager(IUserCommentDal userCommentDal) : IUserCommentService
    {
        private readonly IUserCommentDal _userCommentDal = userCommentDal;
        public IResult Add(UserComment userComment)
        {
            _userCommentDal.Add(userComment);
            return new SuccessResult("User Comment added");
        }

        public IResult Delete(int id)
        {
            var result = _userCommentDal.Get(u => u.Id == id);
            if (result != null)
            {
                result.IsDelete = true;
                _userCommentDal.Delete(result);

                return new SuccessResult("User Comment deleted");
            }
            return new ErrorResult("User Comment not found");
        }

        public IDataResult<List<UserComment>> GetAll()
        {
            var result = _userCommentDal.GetAll(u => u.IsDelete == false);
            if (result.Count > 0)
                return new SuccessDataResult<List<UserComment>>(result, "User Comment loaded");
            return new ErrorDataResult<List<UserComment>>(result, "User Comment not found");
        }

        public IResult Update(UserComment userComment)
        {
            var result = _userCommentDal.Get(u => u.Id == userComment.Id);
            if (result != null)
            {
                _userCommentDal.Update(userComment);
                return new SuccessResult("User Comment updated");
            }
            return new ErrorResult("User Comment not found");
        }
    }
}
