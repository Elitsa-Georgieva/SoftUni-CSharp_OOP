﻿using System;
using System.Collections.Generic;
using _04.WildFarm.Models.Food;

namespace _04.WildFarm.Models.Animal
{
    public class Dog : Mammal
    {
        private const double Weight_Miltiplier = 0.40;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override ICollection<Type> PrefferedFood => new List<Type>() {typeof(Meat)};
        public override double WeightMultiplier => Weight_Miltiplier;
        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override string ToString()
        {
            return base.ToString() + $" {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
