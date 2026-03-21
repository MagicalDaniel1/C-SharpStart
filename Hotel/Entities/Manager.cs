namespace Hotel.Entities;

public class Manager(string name, string surname, string email, string phoneNumber, int age,
    decimal salary) : Employee(name, surname, email, phoneNumber, age, salary, "Manager", "Administration")
{
    private readonly string _name = name;
    private readonly string _surname = surname;

    public void CheckHotelStatus(Hotel hotel)
    {
        Console.WriteLine("Checking hotel status...");
        foreach (var room in hotel.Rooms)
        {
            if (!room.IsClean)
            {
                Console.WriteLine($"The room №{room.RoomNumber} is dirty");
                foreach (var employee in hotel.Employees)
                {
                    if (employee is Housekeeper housekeeper)
                    {
                        housekeeper.IncreaseSalary(-(housekeeper.Salary * 0.01m));
                        Console.WriteLine($"{housekeeper.Name} {housekeeper.Surname} had 1% withheld from his salary");
                    }
                }
            }
        }
    }

    public override void Work()
    {
        Console.WriteLine($"Working as Manager... Manager name: {_name} {_surname}");
    }
}