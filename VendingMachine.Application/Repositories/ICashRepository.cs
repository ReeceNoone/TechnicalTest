using VendingMachine.Application.Contracts;

namespace VendingMachine.Application.Repositories;

public interface ICashRepository
{
    public void AddCoin(ICoin coin);
    
    public int Count(Func<ICoin, bool> func);
}