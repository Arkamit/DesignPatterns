namespace FactoryMethodPattern;

internal class ChickenBurger : Burger
{
    private readonly int TableNumber = Random.Shared.Next(1, 11);

    public ChickenBurger() : base()
    {
        Name = "Chicken Burger";
        Price = 40;
    }
    internal override void Prepare()
    {
        Console.WriteLine($"Preparing {Name}");
    }

    internal override void Serve()
    {
        Console.WriteLine($"Serving {Name} at Table: {TableNumber}");
    }

    internal void BillGenerate()
    {
        Console.WriteLine($"Bill Generated for {Name} at Table {TableNumber}, Amount: {Price}");
    }
}
