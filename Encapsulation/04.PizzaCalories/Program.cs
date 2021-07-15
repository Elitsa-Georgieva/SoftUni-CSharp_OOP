using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizzaName = Console.ReadLine().Split()[1];
            var doughData = Console.ReadLine().Split();

            string flourType = doughData[1];
            string bakingTechnique = doughData[2];
            int weight = int.Parse(doughData[3]);

            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(pizzaName, dough);

                while (true)
                {
                    var line = Console.ReadLine();

                    if (line == "END")
                    {
                        break;
                    }

                    var parts = line.Split();

                    var toppingName = parts[1];
                    var toppingWeight = int.Parse(parts[2]);

                    var topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);
                }
                Console.WriteLine($"{pizzaName} - {pizza.GetCalories():F2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }
    }
}
