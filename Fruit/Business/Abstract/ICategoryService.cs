using Business.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(int id);
        IDataResult<List<Category>> GetAllCategories();
        //IDataResult<Product> GetCategory(int id);
    }
}
