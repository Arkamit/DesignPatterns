namespace FactoryMethodPattern;

abstract class Burger
{
    public string Name { get; set; }
    public int Price { get; set; }

    internal abstract void Prepare();

    internal abstract void Serve();
}
