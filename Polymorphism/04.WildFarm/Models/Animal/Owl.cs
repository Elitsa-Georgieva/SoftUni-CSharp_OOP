using System;
using System.Collections.Generic;
using _04.WildFarm.Models.Food;
using _04.WildFarm.Models.Food.Contracts;

namespace _04.WildFarm.Models.Animal
{
    public class Owl : Bird
    {
        private const double Weight_Miltiplier = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override ICollection<Type> PrefferedFood => new List<Type>() {typeof(Meat)};
        public override double WeightMultiplier => Weight_Miltiplier;
        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
