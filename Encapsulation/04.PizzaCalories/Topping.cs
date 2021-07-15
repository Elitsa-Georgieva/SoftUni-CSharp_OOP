using System;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private string name;
        private int weight;

        public Topping(string name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                var valueAsLower = value.ToLower();

                if (valueAsLower != "meat"
                    && valueAsLower != "veggies"
                    && valueAsLower != "cheese"
                    && valueAsLower != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.name = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                Validator.ThrowIfNumberIsNotInRange(1, 50, value,
                    $"{this.name} weight should be in the range[1..50].");

                this.weight = value;
            }

        }

        public double GetCalories()
        {
            var modifier = GetModifier();

            return this.Weight * 2 * modifier;
        }

        private double GetModifier()
        {
            var nameToLower = this.Name.ToLower();

                //•	Meat - 1.2;
                //•	Veggies - 0.8;
                //•	Cheese - 1.1;
                //•	Sauce - 0.9;

                if (nameToLower == "meat")
                {
                    return 1.2;
                }

                if (nameToLower == "veggies")
                {
                    return 0.8;
                }

                if (nameToLower == "cheese")
                {
                    return 1.1;
                }

                return 0.9;
        }
    }
}
