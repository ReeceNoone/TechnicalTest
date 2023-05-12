using VendingMachine.Application;
using VendingMachine.Application.Contracts;

namespace VendingMachine.Client;

public static class Program
{
    public static void Main(string[] args)
    {
        var machine = new Machine();

        // Populate the machine with some products
        Enumerable.Range(0, Random.Shared.Next(0, 5)).ToList().ForEach(_ => machine.AddProduct("A1", "Cola", 100));
        Enumerable.Range(0, Random.Shared.Next(0, 5)).ToList().ForEach(_ => machine.AddProduct("A2", "Crisps", 50));
        Enumerable.Range(0, Random.Shared.Next(0, 5)).ToList().ForEach(_ => machine.AddProduct("A3", "Chocolate", 65));

        while (true) // TODO: Add a way to exit the application
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to the Vending Machine!");

            BeginNextTransaction(machine);
        }
    }

    private static void BeginNextTransaction(Machine machine)
    {
        var transaction = machine.BeginTransaction();
        var products = machine.GetProducts().ToList();

        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id} - {product.Name} {product.ListPrice}");
        }

        while (true) // TODO: Make this loop conditional rather than relying on a break
        {
            if (GetProduct(products, transaction))
                break;
        }

        // TODO: Implement check for sufficient stock

        while (true) // TODO: Make this loop conditional rather than relying on a break
        {
            if (GetCoin(transaction))
                break;
        }
        
        // Calculate the change
        if (!transaction.TryGetChange(out var change))
        {
            Console.WriteLine("Unable to provide change.");
            Console.WriteLine("Transaction cancelled.");
        }
        else
        {
            Console.WriteLine($"Change: {string.Join(' ', change!.Select(x => x.Name))}");
        }
    }

    private static bool GetCoin(ITransaction transaction)
    {
        Console.WriteLine($"Total input: {transaction.GetTotal() / 100.0:C}");
        Console.Write("Please insert coins, write an empty line to finish:");

        var input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
            return true;

        try
        {
            var coin = ICoin.GetCoin(input);
            transaction.AddCoin(coin);
        }

        catch (ArgumentException)
        {
            Console.WriteLine("Invalid coin.");
        }

        return false;
    }

    private static bool GetProduct(IEnumerable<IProduct> products, ITransaction transaction)
    {
        Console.Write("Please enter the product ID, or use an empty line to finish:");
        var productId = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(productId))
        {
            return true;
        }

        var product = products.FirstOrDefault(x => x.Id == productId);

        if (product is null)
        {
            Console.WriteLine("Invalid product ID.");
            return false;
        }

        transaction.AddProduct(product);
        return false;
    }
}