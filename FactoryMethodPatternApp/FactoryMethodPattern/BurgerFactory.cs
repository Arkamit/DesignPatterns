namespace FactoryMethodPattern;

internal class BurgerFactory
{
    private readonly string BurgerType;
    private readonly string SpecialIngredient;

    public BurgerFactory(string type, string? specialIngredient)
    {
        BurgerType = type;
        SpecialIngredient = specialIngredient ?? string.Empty;
    }

    internal Burger OrderBurger()
    {
        return BurgerType.ToLower() switch
        {
            "chicken" => new ChickenBurger(),
            "vegetable" => new VegetableBurger(!string.IsNullOrWhiteSpace(SpecialIngredient) ? SpecialIngredient : "Paneer"),
            _ => throw new ArgumentException("Invalid Burger Type"),
        };
    }
}
