using VendingMachine.Application.Contracts;

namespace VendingMachine.Application.Repositories.Implementations;

public class CashRepository : ICashRepository
{
    private readonly List<ICoin> _coins;

    public CashRepository()
    {
        _coins = new List<ICoin>();
    }

    public void AddCoin(ICoin coin)
    {
        _coins.Add(coin);
    }

    public void Remove(int value, int count)
    {
        var coins = _coins.Where(x => x.ValuePennies == value).Take(count).ToList();

        foreach (var coin in coins)
        {
            _coins.Remove(coin);
        }
    }

    public int Count(Func<ICoin, bool> func)
    {
        return _coins.Count(func);
    }
}