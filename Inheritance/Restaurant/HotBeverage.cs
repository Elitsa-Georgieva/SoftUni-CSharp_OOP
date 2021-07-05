using System.Reflection.Metadata.Ecma335;

namespace Restaurant
{
    public class HotBeverage : Beverage
    {
        public HotBeverage(string name, decimal price, double milliliters)
            : base(name, price, milliliters)
        {
            
        }
    }
}
