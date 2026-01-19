using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product, PostgreContext>, IProductDal
{
    public List<ProductDetailDto> GetProductDetails()
    {
        using PostgreContext context = new PostgreContext();
        var result = from p in context.Products
                     join c in context.Categories
                     on p.CategoryId equals c.CategoryId
                     select new ProductDetailDto
                     {
                         ProductId = p.ProductId,
                         ProductName = p.ProductName,
                         CategoryName = c.CategoryName,
                         UnitInStock = p.UnitInStock
                     };
        return result.ToList();
    }
}