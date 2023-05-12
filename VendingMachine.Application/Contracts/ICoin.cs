namespace VendingMachine.Application.Contracts.Money;

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
            OnePenceCoinName => new OnePenceCoin(),
            TwoPenceCoinName => new TwoPenceCoin(),
            FivePenceCoinName => new FivePenceCoin(),
            TenPenceCoinName => new TenPenceCoin(),
            TwentyPenceCoinName => new TwentyPenceCoin(),
            FiftyPenceCoinName => new FiftyPenceCoin(),
            OnePoundCoinName => new OnePoundCoin(),
            TwoPoundCoinName => new TwoPoundCoin(),
            _ => throw new ArgumentException("Invalid coin name.")
        };
    }
}