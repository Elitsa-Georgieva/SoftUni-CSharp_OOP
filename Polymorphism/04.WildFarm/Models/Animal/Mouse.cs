using System;
using System.Collections.Generic;
using _04.WildFarm.Models.Food;

namespace _04.WildFarm.Models.Animal
{
    public class Mouse : Mammal
    {
        private const double Weight_Miltiplier = 0.10;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override ICollection<Type> PrefferedFood => new List<Type>() {typeof(Vegetable), typeof(Fruit)};
        public override double WeightMultiplier => Weight_Miltiplier;
        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $" {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
