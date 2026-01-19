using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;

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
        var productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
        if (productToDelete != null)
            _products.Remove(productToDelete);
    }

    public Product? Get(Expression<Func<Product, bool>> filter)
    {
        return _products.SingleOrDefault(filter.Compile());
    }

    public List<Product> GetAll()
    {
        return _products;
    }

    public List<Product> GetAll(Expression<Func<Product, bool>>? filter = null)
    {
        return filter == null
            ? _products
            : _products.Where(filter.Compile()).ToList();
    }

    public void Update(Product product)
    {
        var productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
        if (productToUpdate != null)
        {
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}
