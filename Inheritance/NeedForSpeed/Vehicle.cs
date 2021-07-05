using System;

namespace NeedForSpeed
{
    public class Vehicle
    {
        //•	DefaultFuelConsumption – double 
        //•	FuelConsumption – virtual double
        //•	Fuel – double
        //•	HorsePower – int

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        private const double DefaultFuelConsumtion = 1.25;
        public virtual double FuelConsumption => DefaultFuelConsumtion;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.FuelConsumption;
            Console.WriteLine($"Km driven --> {kilometers}");
        }

    }
}
