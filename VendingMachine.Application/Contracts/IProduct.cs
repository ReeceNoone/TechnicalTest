namespace VendingMachine.Application.Contracts;

public interface IProduct
{
    public string Id { get; }
    
    public string Name { get; }

    public int PricePennies { get; }
    
    public string ListPrice { get; }
}