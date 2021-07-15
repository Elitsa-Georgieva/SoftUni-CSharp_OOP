﻿using _04.WildFarm.Models.Food;
using _04.WildFarm.Models.Food.Contracts;

namespace _04.WildFarm.Factories
{
    public class FoodFactory
    {
        public IFood ProduceFood(string type, int quantity)
        {
            IFood food = null;

            if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }

            return food;
        }
    }
}
