using VendingMachine.Application.Contracts;

namespace VendingMachine.Application.Models;

public class GenericDenomination : ICoin
{
    public GenericDenomination(int valuePennies, string name)
    {
        ValuePennies = valuePennies;
        Name = name;
    }

    public string Name { get; }

    public int ValuePennies { get; }

    public static ICoin OnePennyCoin()
    {
        return new GenericDenomination(1, ICoin.OnePenceCoinName);
    }
    
    public static ICoin TwoPenceCoin()
    {
        return new GenericDenomination(2, ICoin.TwoPenceCoinName);
    }
    
    public static ICoin FivePenceCoin()
    {
        return new GenericDenomination(5, ICoin.FivePenceCoinName);
    }
    
    public static ICoin TenPenceCoin()
    {
        return new GenericDenomination(10, ICoin.TenPenceCoinName);
    }
    
    public static ICoin TwentyPenceCoin()
    {
        return new GenericDenomination(20, ICoin.TwentyPenceCoinName);
    }
    
    public static ICoin FiftyPenceCoin()
    {
        return new GenericDenomination(50, ICoin.FiftyPenceCoinName);
    }
    
    public static ICoin OnePoundCoin()
    {
        return new GenericDenomination(100, ICoin.OnePoundCoinName);
    }
    
    public static ICoin TwoPoundCoin()
    {
        return new GenericDenomination(200, ICoin.TwoPoundCoinName);
    }
}