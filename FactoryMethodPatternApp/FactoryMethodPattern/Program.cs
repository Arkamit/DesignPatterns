using FactoryMethodPattern;

Burger burger;

// Ordering a Vegetable Burger with Tomato as special ingredient
BurgerFactory factory = new BurgerFactory("Vegetable", "Tomato");
burger = factory.OrderBurger();
burger.Prepare();
burger.Serve();
((VegetableBurger)burger).BillGenerate();
Console.WriteLine();

//Ordering a Chicken Burger
factory = new BurgerFactory("Chicken", null);
burger = factory.OrderBurger();
burger.Prepare();
burger.Serve();
((ChickenBurger)burger).BillGenerate();
Console.WriteLine();

// Ordering a Vegetable Burger with no special ingredient. It should default to Paneer.
factory = new BurgerFactory("Vegetable", null);
burger = factory.OrderBurger();
burger.Prepare();
burger.Serve();
((VegetableBurger)burger).BillGenerate();
Console.WriteLine();