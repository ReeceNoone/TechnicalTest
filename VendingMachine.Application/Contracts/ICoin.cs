using VendingMachine.Application.Models;

namespace VendingMachine.Application.Contracts;

public interface ICoin
{
    public const string OnePenceCoinName = "1p";
    public const string TwoPenceCoinName = "2p";
    public const string FivePenceCoinName = "5p";
    public const string TenPenceCoinName = "10p";
    public const string TwentyPenceCoinName = "20p";
    public const string FiftyPenceCoinName = "50p";
    public const string OnePoundCoinName = "£1";
    public const string TwoPoundCoinName = "£2";

    public string Name { get; }

    public int ValuePennies { get; }

    public static ICoin GetCoin(string name)
    {
        return name switch
        {
            OnePenceCoinName => new GenericDenomination(1, OnePenceCoinName),
            TwoPenceCoinName => new GenericDenomination(2, TwoPenceCoinName),
            FivePenceCoinName => new GenericDenomination(5, FivePenceCoinName),
            TenPenceCoinName => new GenericDenomination(10, TenPenceCoinName),
            TwentyPenceCoinName => new GenericDenomination(20, TwentyPenceCoinName),
            FiftyPenceCoinName => new GenericDenomination(50, FiftyPenceCoinName),
            OnePoundCoinName => new GenericDenomination(100, OnePoundCoinName),
            TwoPoundCoinName => new GenericDenomination(200, TwoPoundCoinName),
            _ => throw new ArgumentException("Invalid coin name.")
        };
    }
}