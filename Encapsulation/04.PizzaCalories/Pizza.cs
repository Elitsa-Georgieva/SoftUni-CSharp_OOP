using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private const int MaxToppingCount = 10;
        private const int NameMinLength = 1;
        private const int NameMaxLength = 1;

        //name, dough and toppings
        private string name;
        private Dough dough;
        //private string topping;
        private List<Topping> toppings;
        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < NameMinLength && value.Length > NameMaxLength)
                {
                    throw new ArgumentException(
                        $"Pizza name should be between {NameMinLength} and {NameMaxLength} symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == MaxToppingCount)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [0..{MaxToppingCount}].");
            }
            this.toppings.Add(topping);
        }

        public double GetCalories()
        {
            return this.dough.GetCalories() + this.toppings.Sum(t => t.GetCalories());
        }
    }
}
