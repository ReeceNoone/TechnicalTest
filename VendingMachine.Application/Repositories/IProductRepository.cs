using VendingMachine.Application.Contracts;

namespace VendingMachine.Application.Repositories;

public interface IProductRepository
{
    public IEnumerable<IProduct> GetProducts();
    
    public void AddProduct(IProduct product);
}