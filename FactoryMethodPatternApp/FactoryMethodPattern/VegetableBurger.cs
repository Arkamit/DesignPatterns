namespace FactoryMethodPattern;

internal class VegetableBurger : Burger
{
    private readonly int TableNumber = Random.Shared.Next(1, 11);
    private readonly string SpecialIngredient;

    public VegetableBurger(string specialIngredient) : base()
    {
        Name = "Vegetable Burger";
        Price = 30;
        SpecialIngredient = specialIngredient;
    }
    internal override void Prepare()
    {
        Console.WriteLine($"Preparing {Name}");
    }

    internal override void Serve()
    {
        Console.WriteLine($"Serving {Name} with {SpecialIngredient} at Table: {TableNumber}");
    }

    internal void BillGenerate()
    {
        Console.WriteLine($"Bill Generated for {Name} with {SpecialIngredient} at Table {TableNumber}, Amount: {Price}");
    }
}
