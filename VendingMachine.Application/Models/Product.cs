using VendingMachine.Application.Contracts;

namespace VendingMachine.Application.Models;

public class Product : IProduct
{
    public string Id { get; }
    public string Name { get; }

    public int PricePennies { get; }
    
    public string ListPrice => $"{PricePennies / 100}.{PricePennies % 100:00}";

    public Product(string id, string name, int pricePennies)
    {
        Id = id;
        Name = name;
        PricePennies = pricePennies;
    }
}