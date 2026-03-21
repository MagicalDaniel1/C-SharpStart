namespace Hotel.Entities;

public class Hotel(
    string name,
    string address,
    List<Room> rooms,
    List<Guest> guests,
    List<Employee> employees,
    decimal totalRevenue)
{
    public string Name { get; set; } = name;
    public string Address { get; set; } = address;

    public List<Room> Rooms { get; set; } = rooms;
    public List<Employee> Employees { get; set; } = employees;

    public decimal TotalRevenue { get; set; } = totalRevenue;
    public int StarRating { get; set; }
    
    public void AddRoom(Room room) => Rooms.Add(room);
    public void AddEmployee(Employee employee) => Employees.Add(employee);
    public void AddProfit(decimal profit) => TotalRevenue += profit;
    
    public Room? FindRoomByNumber(int roomNumber)
        => Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

    public class HotelStars
    {
        public void UpdatePrices(Hotel hotel, int stars)
        {
            hotel.StarRating = stars;
            decimal priceMultiplier = stars switch
            {
                5 => 4.5m,
                4 => 3.0m,
                3 => 2.2m,
                2 => 1.5m,
                _ => 1.0m
            };
            foreach (var room in hotel.Rooms)
            {
                decimal basePrice = (decimal)room.RoomType;
                decimal newPrice = basePrice * priceMultiplier;
                if (room.ViewType == Enums.ViewType.MountainView) newPrice *= 1.1m;
                if (room.ViewType == Enums.ViewType.SeaView) newPrice *= 1.2m;
                
                room.Price = newPrice;
            }
        }
    }
    
    public void ShowAllRooms()
    {
        Console.WriteLine("All rooms: ");
        foreach (var room in Rooms)
        {
            room.Info();
        }
    }

    public void ShowFreeRooms()
    {
        Console.WriteLine("Free rooms: ");
        foreach (var room in Rooms.Where(room => !room.IsOccupied))
        {
            if (!room.IsOccupied)
            {
                room.Info();
            }
        }   
    }
    
    public void Info()
    {
        Console.WriteLine($"Hotel name: {Name}");
        Console.WriteLine($"Hotel address: {Address}");
        Console.WriteLine($"Hotel rooms: {Rooms.Count}");
        Console.WriteLine($"Hotel employees: {Employees.Count}");
        Console.WriteLine($"Hotel total revenue: {TotalRevenue}");
    }
}