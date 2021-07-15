using System;

namespace _01.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] truckTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Vehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]));
            Vehicle truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]));

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
                    else //Truck
                    {
                        CanDrive(truck, amount);
                    }
                }
                else //Refuel
                {
                    if (type == "Car")
                    {
                        car.Refuel(amount);
                    }
                    else
                    {
                        truck.Refuel(amount);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }

        public  static void CanDrive(Vehicle vehicle, double distance)
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
