namespace Hotel;
using Hotel.Entities;

public class EmployeeSalary
{
    public void Payout(Hotel hotel)
    {
        foreach (var employee in hotel.Employees)
        {
            decimal amountPay = employee.Salary;
            if (hotel.TotalRevenue >= amountPay)
            {
                hotel.TotalRevenue -= amountPay;
                employee.Balance += amountPay;
                Console.WriteLine($"The hotel paid {amountPay} to {employee.Name} {employee.Surname}");
            }
            else
            {
                Console.WriteLine($"The hotel cannot pay a salary to {employee.Name} {employee.Surname}");
            }
        }
        Console.WriteLine($"The hotel budget: {hotel.TotalRevenue}");
    }
}