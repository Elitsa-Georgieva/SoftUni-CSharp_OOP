using System;
using System.Collections.Generic;
using _04.WildFarm.Models.Food;

namespace _04.WildFarm.Models.Animal
{
    public class Hen : Bird
    {
        private const double Weight_Miltiplier = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override ICollection<Type> PrefferedFood => new List<Type>()
            {typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds)};
        public override double WeightMultiplier => Weight_Miltiplier;
        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
