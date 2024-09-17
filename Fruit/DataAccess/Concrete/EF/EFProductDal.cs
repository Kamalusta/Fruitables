using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace DataAccess.Concrete.EF
{
    public class EFProductDal : BaseRepository<Product, BaseProjectContext>, IProductDal
    {
        public List<ProductCategoryDto> GetProductsByCategory(int categoryId)
        {
            var context = new BaseProjectContext();

            var result = from p in context.Products
                         where p.IsDelete == false && p.CategoryId == categoryId
                         join c in context.Categories
                         on p.CategoryId equals c.Id
                         select new ProductCategoryDto
                         {
                             CategoryId = c.Id,
                             ProductId = p.Id,
                             ProductName = p.Name,
                             CategoryName = c.Name,
                             ProductPrice = p.Price
                         };
            return result.ToList();
        }

        public List<Product> GetProductsByName(string name)
        {
            var context = new BaseProjectContext();           

            var result = context.Products.Where(p=>p.Name.Contains(name)).ToList();
            return result.ToList();
        }
    }
}
