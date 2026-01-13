using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Concrete.InMemory;

public class InMemoryProductDal : IProductDal
{
    List<Product> _products;
    public InMemoryProductDal()
    {
        _products = new List<Product>
        {
            new Product{ProductId=1,CategoryId=1,ProductName="MousePad",UnitPrice=15,UnitInStock=15},
            new Product{ProductId=2,CategoryId=1,ProductName="Kulaklik",UnitPrice=15,UnitInStock=15},
            new Product{ProductId=3,CategoryId=1,ProductName="Hoparlor",UnitPrice=15,UnitInStock=15},
            new Product{ProductId=4,CategoryId=2,ProductName="SarjAleti",UnitPrice=15,UnitInStock=15},
            new Product{ProductId=5,CategoryId=2,ProductName="UsbBellek",UnitPrice=15,UnitInStock=15},
            new Product{ProductId=6,CategoryId=2,ProductName="Mouse",UnitPrice=15,UnitInStock=15}
        };
    }
    public void Add(Product product)
    {
        _products.Add(product);
    }

    public void Delete(Product product)
    {
        Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
        _products.Remove(productToDelete);
    }

    public List<Product> GetAll()
    {
        return _products;
    }

    public void Update(Product product)
    {
        Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
        productToUpdate.ProductName = product.ProductName;
        productToUpdate.CategoryId = product.CategoryId;
        productToUpdate.UnitPrice = product.UnitPrice;
        productToUpdate.UnitInStock = product.UnitInStock;
    }
}
