using Entities.Abstract;

namespace Entities.Concrete;

public class Customer : IEntity
{
    public string CustomerId { get; set; } = string.Empty;
    public string ContactName { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
}