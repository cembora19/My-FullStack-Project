// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

// ProductTest();
CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
foreach (var category in categoryManager.GetAll())
{
    Console.WriteLine(category.CategoryName);
}


static void ProductTest()
{
    ProductManager productManager = new ProductManager(new InMemoryProductDal());
    foreach (var product in productManager.GetAllByCategoryId(2))
    {
        Console.WriteLine(product.ProductName);
    }
}
