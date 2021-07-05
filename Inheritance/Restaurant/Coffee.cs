namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double DefaultCoffeMilliliters = 50;
        private const decimal DefaultCoffePrice = 3.50M;
        public Coffee(string name, double caffeine)
            : base(name, DefaultCoffePrice, DefaultCoffeMilliliters)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
