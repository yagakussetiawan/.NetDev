using System;
using ParkingSystem.Services;

class Program
{
    static void Main()
    {
        ParkingLot parkingLot = null;
        Console.WriteLine("Enter commands:");
        while (true)
        {
            var input = Console.ReadLine();
            if (input == "exit") break;

            var commands = input.Split(' ');
            switch (commands[0])
            {
                case "create_parking_lot":
                    parkingLot = new ParkingLot(int.Parse(commands[1]));
                    break;
                case "park":
                    parkingLot?.Park(commands[1], commands[2], commands[3]);
                    break;
                case "leave":
                    parkingLot?.Leave(int.Parse(commands[1]));
                    break;
                case "status":
                    parkingLot?.Status();
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}
s