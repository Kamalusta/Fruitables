using Business.Abstract;
using Business.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;

namespace Business.Concrete
{
    public class ProductManager(IProductDal productDal) : IProductService
    {
        private readonly IProductDal _productDal = productDal;
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult("Product added");
        }

        public IResult Delete(int id)
        {
            Product deletedProduct = null;
            Product resultProduct = _productDal.Get(p => p.Id == id);
            if (resultProduct != null)
                deletedProduct = resultProduct;
            deletedProduct.IsDelete = true;
            _productDal.Delete(deletedProduct);
            return new SuccessResult("Product deleted");
        }

        public IDataResult<List<Product>> GetAllProducts()
        {
            var products = _productDal.GetAll(p => p.IsDelete == false).ToList();
            if (products.Count > 0)
                return new SuccessDataResult<List<Product>>(products, "Products loaded");
            else return new ErrorDataResult<List<Product>>(products, "Error");
        }

        public IDataResult<Product> GetProduct(int id)
        {
            var getProduct = _productDal.Get(p => p.Id == id);
            if (getProduct != null)
                return new SuccessDataResult<Product>(getProduct, "Product loaded");
            else return new ErrorDataResult<Product>(getProduct, "Product not found");
        }

        public IDataResult<List<ProductCategoryDto>> GetProductsByCategory(int categoryId)
        {
            var result = _productDal.GetProductsByCategory(categoryId);
            if (result.Count > 0)
                return new SuccessDataResult<List<ProductCategoryDto>>(result, "Products loaded");
            else return new ErrorDataResult<List<ProductCategoryDto>>(result, "Products not found");
        }

        public IDataResult<List<Product>> GetProductsByName(string name)
        {
            var result = _productDal.GetProductsByName(name);
            if (result.Count > 0)
                return new SuccessDataResult<List<Product>>(result, "Products loaded");
            else return new ErrorDataResult<List<Product>>(result, "Products not found");
        }

        public IResult Update(Product product)
        {
            Product updatedProduct = _productDal.Get(p => p.Id == product.Id && p.IsDelete == false);
            updatedProduct.Name = product.Name;
            updatedProduct.Description = product.Description;
            updatedProduct.Price = product.Price;
            updatedProduct.CategoryId = product.CategoryId;
            updatedProduct.DiscountRate = product.DiscountRate;
            updatedProduct.IsDiscount = product.IsDiscount;
            updatedProduct.Count = product.Count;
            updatedProduct.Image = product.Image;
            updatedProduct.IsDelete = product.IsDelete;
            _productDal.Update(product);
            return new SuccessResult("Product updated");
        }
    }
}
