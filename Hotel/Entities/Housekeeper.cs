namespace Hotel.Entities;

public class Housekeeper(string name, string surname, string email, string phoneNumber,
    int age, decimal salary) : Employee(name, surname, email, phoneNumber, age, salary, "Housekeeper", "Cleaners Department")
{
    private readonly string _name = name;
    private readonly string _surname = surname;
    
    public void Clean(Room room)
    {
        if (room.IsClean)
        {
            Console.WriteLine("Room is already clean.");
            return;
        }
            
        Console.WriteLine("Cleaning...");
        room.Clean();
        
        Console.WriteLine("Room is clean.");
    }

    public override void Work()
    {
        Console.WriteLine($"Working as Housekeeper... Housekeeper name: {_name} {_surname}");
    }
}