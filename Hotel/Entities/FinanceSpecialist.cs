namespace Hotel.Entities;

public class FinanceSpecialist(string name, string surname, string email, string phoneNumber, int age,
    decimal salary) : Employee(name, surname, email, phoneNumber, age, salary, "Finance Specialist", "Administration")
{
    public void CheckHotelRevenue(Hotel hotel)
    {
        Console.WriteLine($"Hotel total revenue: {hotel.TotalRevenue}");
    }
}