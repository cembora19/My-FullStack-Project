// See https://aka.ms/new-console-template for more information
using Business.Concrete;


ProductManager productManager = new ProductManager(new InMemoryProductDal());
foreach (var product in productManager.GetAllByCategoryId(2))
{
    Console.WriteLine(product.ProductName);
}