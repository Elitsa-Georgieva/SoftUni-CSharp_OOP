using System;

namespace _02.VehiclesExtension
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] busTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]), double.Parse(carTokens[3]));
            Vehicle truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]), double.Parse(truckTokens[3]));
            Bus bus = new Bus(double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3]));

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] currCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = currCommand[0];
                string type = currCommand[1];
                double amount = double.Parse(currCommand[2]);

                if (command == "Drive")
                {
                    if (type == "Car")
                    {
                        CanDrive(car, amount);
                    }
                    else if(type == "Truck")//Truck
                    {
                        CanDrive(truck, amount);
                    }
                    else
                    {
                        bus.IsEmpty = false;
                        CanDrive(bus, amount);
                    }
                }
                else if(command == "Refuel")//Refuel
                {
                    try
                    {
                        if (type == "Car")
                        {
                            car.Refuel(amount);
                        }
                        else if (type == "Truck")
                        {
                            truck.Refuel(amount);
                        }
                        else
                        {
                            bus.Refuel(amount);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else //drive empty
                {
                    bus.IsEmpty = true;
                    CanDrive(bus, amount);
                }

            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }

        public static void CanDrive(Vehicle vehicle, double distance)
        {
            bool canDrive = vehicle.CanDrive(distance);
            string vehicleType = vehicle.GetType().Name;
            string result = canDrive
                ? $"{vehicleType} travelled {distance} km"
                : $"{vehicleType} needs refueling";

            Console.WriteLine(result);
        }
    }
}
