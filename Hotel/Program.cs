namespace Hotel;

using Hotel.Entities;
using Hotel.Enums;
using Hotel.Services;

public class Program
{
    static void Main()
    {
        var grandHotel = new Hotel("Grand de sanguis", "Wall street, 12", new List<Room>(), new List<Guest>(),
            new List<Employee>(), 5000m);
        var hotelStars = new Hotel.HotelStars();
        var luxuryDeRoom = new Room(101, 1, RoomType.Luxury, ViewType.SeaView, false, true, null);
        var basicRoom = new Room(102, 1, RoomType.SingleRoom, ViewType.Basic, false, false, null);
        
        grandHotel.AddRoom(luxuryDeRoom);
        grandHotel.AddRoom(basicRoom);
        
        hotelStars.UpdatePrices(grandHotel, 5);

        var manager = new Manager("Alex", "Starten", "alexxx@gmail.com", "+38 061 032 1882", 40, 2000m);
        var housekeeper = new Housekeeper("Marry", "Valten", "marryvaall@gmail.com", "+38 061 053 2416", 30, 800m);
        
        grandHotel.AddEmployee(manager);
        grandHotel.AddEmployee(housekeeper);

        var guest = new Guest("Emmy", "Vampir", "emmvaaaall@gmail.com", "+38 051 045 1212", 99999, 11100m);
        guest.StayDays = 2;
        luxuryDeRoom.CheckIn(guest, grandHotel);
        
        luxuryDeRoom.Fridge.AddDrink(new Drink("Coca-Cola", 15m));
        luxuryDeRoom.Fridge.AddDrink(new Drink("Whiskey", 150m));
        
        guest.TakeDrink(luxuryDeRoom, "Coca-Cola", grandHotel);
        guest.TakeDrink(luxuryDeRoom, "Whiskey", grandHotel);
        
        manager.CheckHotelStatus(grandHotel);
        housekeeper.Clean(basicRoom);

        var salaryService = new EmployeeSalary();
        salaryService.Payout(grandHotel);
        
        grandHotel.Info();
    }
}