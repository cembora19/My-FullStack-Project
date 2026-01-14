using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfProductDal : IEntityRepository<Product>
{
    private readonly PostgreContext _context;

    public EfProductDal(PostgreContext context)
    {
        _context = context;
    }

    public void Add(Product entity)
    {
        _context.Products.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(Product entity)
    {
        _context.Products.Remove(entity);
        _context.SaveChanges();
    }

    public Product Get(Expression<Func<Product, bool>> filter)
    {
        return _context.Products.SingleOrDefault(filter);
    }

    public List<Product> GetAll(Expression<Func<Product, bool>>? filter = null)
    {
        return filter == null
            ? _context.Products.ToList()
            : _context.Products.Where(filter).ToList();
    }

    public void Update(Product entity)
    {
        _context.Products.Update(entity);
        _context.SaveChanges();
    }
}