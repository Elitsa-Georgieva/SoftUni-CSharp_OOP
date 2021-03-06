namespace _02.VehiclesExtension
{
    class Bus : Vehicle
    {
        private const double AirConditionerConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public bool IsEmpty { get; set; }

        public override double FuelConsumption => this.IsEmpty
            ? base.FuelConsumption
            : base.FuelConsumption + AirConditionerConsumption;
    }
}
