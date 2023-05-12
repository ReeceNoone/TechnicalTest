using VendingMachine.Application.Contracts.Money;

namespace VendingMachine.Application.Repositories.Implementations;

public class CashService : ICashRepository
{
    public bool CanMakeChange(int changeAmount)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ICoin> GetChange(int amount)
    {
        throw new NotImplementedException();
    }

    public void AddCoin(ICoin coin)
    {
        throw new NotImplementedException();
    }
}