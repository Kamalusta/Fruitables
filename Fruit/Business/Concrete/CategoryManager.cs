using Business.Abstract;
using Business.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager(IBaseRepository<Category> categoryDal) : ICategoryService
    {
        private readonly IBaseRepository<Category> _categoryDal = categoryDal;
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult("Category added");
        }

        public IResult Delete(int id)
        {
            Category deleteCategory = null;
            Category  result = _categoryDal.Get(c=>c.Id == id);
            if (result != null)
                deleteCategory = result;
            deleteCategory.IsDelete = true;
            _categoryDal.Delete(deleteCategory);
            return new SuccessResult("Category deleted");
        }

        public IDataResult<List<Category>> GetAllCategories()
        {
            var result = _categoryDal.GetAll(c => c.IsDelete == false).ToList();
            if (result.Count > 0)
                return new SuccessDataResult<List<Category>>(result, "Categories loaded");
            else return new ErrorDataResult<List<Category>>(result, "Category not found");            
        }

        public IResult Update(Category category)
        {
            Category updatedCategory = _categoryDal.Get(c=> c.Id == category.Id && category.IsDelete == false);
            updatedCategory.Name = category.Name;
            updatedCategory.IsDelete= category.IsDelete;
            _categoryDal.Update(category);
            return new SuccessResult("Category updated");
        }
    }
}
