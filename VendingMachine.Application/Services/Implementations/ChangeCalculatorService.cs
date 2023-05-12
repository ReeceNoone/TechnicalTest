using VendingMachine.Application.Contracts;
using VendingMachine.Application.Models;
using VendingMachine.Application.Repositories;

namespace VendingMachine.Application.Services.Implementations;

public class ChangeCalculatorService : IChangeCalculatorService
{
    private readonly ICashRepository _cashRepository;

    public ChangeCalculatorService(ICashRepository cashRepository)
    {
        _cashRepository = cashRepository;
    }

    public IEnumerable<ICoin> GetChange(int changeAmount)
    {
        var totalRequired = changeAmount;
        var coins = new List<ICoin>();

        var twoPoundsRequired = DenominationCalculator(totalRequired, 200);
        totalRequired -= twoPoundsRequired * 200;
        
        var onePoundsRequired = DenominationCalculator(totalRequired, 100);
        totalRequired -= onePoundsRequired * 100;
        
        var fiftyPenceRequired = DenominationCalculator(totalRequired, 50);
        totalRequired -= fiftyPenceRequired * 50;
        
        var twentyPenceRequired = DenominationCalculator(totalRequired, 20);
        totalRequired -= twentyPenceRequired * 20;
        
        var tenPenceRequired = DenominationCalculator(totalRequired, 10);
        totalRequired -= tenPenceRequired * 10;
        
        var fivePenceRequired = DenominationCalculator(totalRequired, 5);
        totalRequired -= fivePenceRequired * 5;
        
        var twoPenceRequired = DenominationCalculator(totalRequired, 2);
        totalRequired -= twoPenceRequired * 2;
        
        var onePenceRequired = DenominationCalculator(totalRequired, 1);
        totalRequired -= onePenceRequired * 1;
        
        if (totalRequired != 0)
        {
            throw new InvalidOperationException("Not enough money in the machine to make change");
        }
        
        coins.AddRange(Enumerable.Range(0, twoPoundsRequired).Select(_ => GenericDenomination.TwoPoundCoin()));
        coins.AddRange(Enumerable.Range(0, onePoundsRequired).Select(_ => GenericDenomination.OnePoundCoin()));
        coins.AddRange(Enumerable.Range(0, fiftyPenceRequired).Select(_ => GenericDenomination.FiftyPenceCoin()));
        coins.AddRange(Enumerable.Range(0, twentyPenceRequired).Select(_ => GenericDenomination.TwentyPenceCoin()));
        coins.AddRange(Enumerable.Range(0, tenPenceRequired).Select(_ => GenericDenomination.TenPenceCoin()));
        coins.AddRange(Enumerable.Range(0, fivePenceRequired).Select(_ => GenericDenomination.FivePenceCoin()));
        coins.AddRange(Enumerable.Range(0, twoPenceRequired).Select(_ => GenericDenomination.TwoPenceCoin()));
        coins.AddRange(Enumerable.Range(0, onePenceRequired).Select(_ => GenericDenomination.OnePennyCoin()));
        
        return coins;
    }

    private int DenominationCalculator(int totalRequired, int coinValue)
    {
        var countDenominationRequired = (int)Math.Floor((decimal)totalRequired / coinValue);
        var countDenominationAvailable = _cashRepository.Count(x => x.ValuePennies == coinValue);

        if (countDenominationRequired > countDenominationAvailable)
        {
            countDenominationRequired = countDenominationAvailable;
        }
        return countDenominationRequired;
    }
}