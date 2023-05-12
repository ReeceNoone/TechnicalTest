using VendingMachine.Application.Contracts;

namespace VendingMachine.Application.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly List<IProduct> _products;

    public ProductRepository()
    {
        _products = new List<IProduct>();
    }

    public IProduct? GetProduct(Func<IProduct, bool> func)
    {
        return _products.FirstOrDefault(func);
    }

    public IEnumerable<IProduct> GetProducts()
    {
        return _products;
    }

    public void AddProduct(IProduct product)
    {
        if (!_products.Contains(product))
        {
            _products.Add(product);
        }

        else
        {
            throw new ArgumentException("Product already exists.");
        }
    }

    public void RemoveProduct(Func<IProduct, bool> func)
    {
        var product = _products.FirstOrDefault(func);
        
        if (product is not null)
        {
            _products.Remove(product);
        }
    }
}