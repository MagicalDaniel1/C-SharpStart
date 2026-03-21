namespace Hotel.Entities;

public class Drink(string drinkName, decimal drinkCost)
{
    public string Name { get; set; } = drinkName;
    public decimal Cost { get; set; } = drinkCost;
}

public class Minibar
{
    public List<Drink> Drinks { get; set; } = new List<Drink>();
    public void AddDrink(Drink newdrink) => Drinks.Add(newdrink);

    public void ShowDrinks()
    {
        Console.WriteLine("Minibar drinks:");
        foreach (var drink in Drinks) Console.WriteLine($"{drink.Name} - {drink.Cost}");
    }
}