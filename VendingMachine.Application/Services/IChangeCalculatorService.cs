using VendingMachine.Application.Contracts;

namespace VendingMachine.Application.Services;

public interface IChangeCalculatorService
{
    public IEnumerable<ICoin> GetChange(int changeAmount);
}