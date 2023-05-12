namespace VendingMachine.Application.Contracts;

public interface ITransaction
{
    public void AddProduct(IProduct product);

    public void AddCoin(ICoin coin);

    public int GetTotal();

    bool TryGetChange(out IEnumerable<ICoin>? change);
}