using VendingMachine.Application.Contracts;
using VendingMachine.Application.Models;
using VendingMachine.Application.Repositories;
using VendingMachine.Application.Repositories.Implementations;

namespace VendingMachine.Application;

public class Machine
{
    private readonly ICashRepository _cashRepository;
    private readonly IProductRepository _productRepository;

    public Machine()
    {
        _cashRepository = new CashRepository();
        _productRepository = new ProductRepository();
    }

    public ITransaction BeginTransaction()
    {
        return new Transaction(_cashRepository);
    }

    public IEnumerable<IProduct> GetProducts()
    {
        return _productRepository.GetProducts();
    }

    public void AddProduct(string id, string name, int costPennies)
    {
        _productRepository.AddProduct(new Product(id, name, costPennies));
    }
}