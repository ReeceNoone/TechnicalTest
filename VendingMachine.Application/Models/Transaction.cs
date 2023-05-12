using VendingMachine.Application.Contracts;
using VendingMachine.Application.Repositories;
using VendingMachine.Application.Services;
using VendingMachine.Application.Services.Implementations;

namespace VendingMachine.Application.Models;

public class Transaction : ITransaction
{
    private readonly ICashRepository _cashRepository;
    private readonly IChangeCalculatorService _changeCalculatorService;
    
    public ICollection<ICoin> Coins { get; }
    
    public ICollection<IProduct> Products { get; }

    public Transaction(ICashRepository cashRepository)
    {
        _cashRepository = cashRepository;
        _changeCalculatorService = new ChangeCalculatorService(_cashRepository);
        Products = new List<IProduct>();
        Coins = new List<ICoin>();
    }

    public void AddProduct(IProduct product)
    {
        Products.Add(product);
    }

    public void AddCoin(ICoin coin)
    {
        Coins.Add(coin);
        _cashRepository.AddCoin(coin);
    }

    public void AddCoins(IEnumerable<ICoin> coins)
    {
        foreach (var coin in coins)
        {
            Coins.Add(coin);
            _cashRepository.AddCoin(coin);
        }
    }

    public int GetTotal()
    {
        return Coins.Sum(x => x.ValuePennies);
    }

    public bool TryGetChange(out IEnumerable<ICoin>? change)
    {
        var sum = GetTotal();
        var price = Products.Sum(x => x.PricePennies);

        try
        {
            change = _changeCalculatorService.GetChange(sum - price);
            return true;
        }
        catch
        {
            change = null;
            return false;
        }
    }
}