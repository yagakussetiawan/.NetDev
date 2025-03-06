using System;
using System.Collections.Generic;
using System.Linq;

class ParkingLot
{
    private int totalSlots;
    private Dictionary<int, Vehicle> slots;

    public ParkingLot(int size)
    {
        totalSlots = size;
        slots = new Dictionary<int, Vehicle>();
        Console.WriteLine($"Created a parking lot with {size} slots");
    }

    public void Park(string registrationNo, string color, string type)
    {
        if (slots.Count >= totalSlots)
        {
            Console.WriteLine("Sorry, parking lot is full");
            return;
        }
        
        int slot = Enumerable.Range(1, totalSlots).First(s => !slots.ContainsKey(s));
        slots[slot] = new Vehicle(registrationNo, color, type);
        Console.WriteLine($"Allocated slot number: {slot}");
    }

    public void Leave(int slot)
    {
        if (slots.ContainsKey(slot))
        {
            slots.Remove(slot);
            Console.WriteLine($"Slot number {slot} is free");
        }
    }

    public void Status()
    {
        Console.WriteLine("Slot\tNo.\t\tType\tRegistration No\tColour");
        foreach (var slot in slots.OrderBy(s => s.Key))
        {
            var v = slot.Value;
            Console.WriteLine($"{slot.Key}\t{v.RegistrationNo}\t{v.Type}\t{v.Color}");
        }
    }

    public void TypeOfVehicles(string type)
    {
        Console.WriteLine(slots.Values.Count(v => v.Type.Equals(type, StringComparison.OrdinalIgnoreCase)));
    }

    public void VehiclesWithOddPlate()
    {
        var result = slots.Values.Where(v => Helper.IsOddPlate(v.RegistrationNo)).Select(v => v.RegistrationNo);
        Console.WriteLine(string.Join(", ", result));
    }

    public void VehiclesWithEvenPlate()
    {
        var result = slots.Values.Where(v => !Helper.IsOddPlate(v.RegistrationNo)).Select(v => v.RegistrationNo);
        Console.WriteLine(string.Join(", ", result));
    }

    public void VehiclesWithColor(string color)
    {
        var result = slots.Values.Where(v => v.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).Select(v => v.RegistrationNo);
        Console.WriteLine(string.Join(", ", result));
    }

    public void SlotNumbersForColor(string color)
    {
        var result = slots.Where(s => s.Value.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).Select(s => s.Key);
        Console.WriteLine(string.Join(", ", result));
    }

    public void SlotNumberForRegistration(string registrationNo)
    {
        var result = slots.FirstOrDefault(s => s.Value.RegistrationNo.Equals(registrationNo, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine(result.Key != 0 ? result.Key.ToString() : "Not found");
    }
}
