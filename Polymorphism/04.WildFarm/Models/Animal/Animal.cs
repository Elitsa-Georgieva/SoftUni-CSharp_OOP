using System;
using System.Collections;
using System.Collections.Generic;
using _04.WildFarm.Exceptions;
using _04.WildFarm.Models.Animal.Contracts;
using _04.WildFarm.Models.Food.Contracts;

namespace _04.WildFarm.Models.Animal
{
    public abstract class Animal : IAnimal
    {
        private const string UneatebleFoodMessage = "{0} does not eat {1}!";
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public abstract ICollection<Type> PrefferedFood { get; }

        public abstract double WeightMultiplier { get; }
        public abstract string ProduceSound();

        public void Feed(IFood food)
        {
            if (!this.PrefferedFood.Contains(food.GetType()))
            {
                throw new UneatebleFoodException(String.Format(UneatebleFoodMessage, this.GetType().Name,
                    food.GetType().Name));
            }

            this.Weight += this.WeightMultiplier * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name},";
        }
    }
}
