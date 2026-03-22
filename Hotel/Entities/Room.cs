using Hotel.Enums;

namespace Hotel.Entities;

public class Room(int roomNumber, int floor, RoomType roomType, ViewType viewType, bool isOccupied, bool isClean, Guest? guest)
{
    public int RoomNumber { get; set; } = roomNumber;
    private int Floor { get; set; } = floor;
    public RoomType RoomType { get; set; } = roomType;
    public ViewType ViewType { get; set; } = viewType;
    public Minibar Fridge { get; set; } = new Minibar();
    public decimal Price { get; set; }

    public bool IsOccupied { get; set; } = isOccupied;
    public bool IsClean { get; set; } = isClean;
    public Guest? Guest { get; set; } = guest;

    public bool CheckIn(Guest guest, Hotel hotel)
    {
        if (IsOccupied || !IsClean)
        {
            Console.WriteLine("Room is not available.");
            
            return false;
        }
        
        var totalCost = Price * guest.StayDays;
        var getGuestBudget = guest.GetBudget();

        if (getGuestBudget < totalCost)
        {
            Console.WriteLine("Guest budget is not enough.");
            
            return false;
        }
        
        guest.budget -= totalCost;
        hotel.TotalRevenue += totalCost;
        IsOccupied = true;
        Guest = guest;

        Console.WriteLine($"Guest {guest.Name} {guest.Surname} checked in.");
        
        return true;
    }

    public decimal CheckOut()
    {
        if (!IsOccupied || Guest == null)
        {
            Console.WriteLine("Room is not occupied.");
            
            return 0;
        }
        
        var earnedMoney = Price * Guest.StayDays;

        Console.WriteLine("Guest checked out.");
        
        IsOccupied = false;
        Guest = null;
        
        return earnedMoney;
    }
    
    public void Clean()
        => IsClean = true;

    public void Info()
    {
        var guestName = Guest == null ? "No guest" : Guest.Name + " " + Guest.Surname;
        
        Console.WriteLine($"Room number: {RoomNumber}, Floor: {Floor}, Room type: {RoomType}, Guest: {guestName}," +
                          $" Is occupied: {IsOccupied}, Is clean: {IsClean}");
    }
}