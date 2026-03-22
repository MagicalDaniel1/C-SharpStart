namespace Hotel.Entities;

public class Guest(string name, string surname, string email, string phoneNumber, int age, decimal budget)
    : Person(name, surname, email, phoneNumber, age)
{
    public decimal budget { get; set; } = budget;
    public int StayDays { get; set; }
    
    public decimal GetBudget()
    {
        Console.WriteLine($"Getting budget... Budget: {budget}");
        
        return budget;
    }

    public void TakeDrink(Room room, string drinkName, Hotel hotel)
    {
        var drink = room.Fridge.Drinks.FirstOrDefault(d => d.Name == drinkName);
        if (drink == null) {
            Console.WriteLine($"Drink {drinkName} doesn't exist");
            return;
        }

        if (budget >= drink.Cost)
        {
            budget -= drink.Cost;
            hotel.AddProfit(drink.Cost);
            
            room.Fridge.Drinks.Remove(drink);
            Console.WriteLine($"Drink {drinkName} bought by {Name}");
        }
        else
        {
            Console.WriteLine($"{Name} doesn't have enough money to buy");
        }
    }
}