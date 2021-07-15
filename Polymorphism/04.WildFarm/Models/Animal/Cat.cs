using System;
using System.Collections.Generic;
using _04.WildFarm.Models.Food;

namespace _04.WildFarm.Models.Animal
{
    public class Cat : Feline
    {
        private const double Weight_Miltiplier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override ICollection<Type> PrefferedFood => new List<Type>() {typeof(Vegetable), typeof(Meat)};
        public override double WeightMultiplier => Weight_Miltiplier;
        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
