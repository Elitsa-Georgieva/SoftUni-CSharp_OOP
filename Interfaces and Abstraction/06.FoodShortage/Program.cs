using System;
using System.Collections.Generic;
using System.Linq;
using _06.FoodShortage.Interfaces;
using _06.FoodShortage.Models;

namespace _06.FoodShortage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> byersByName = new Dictionary<string, IBuyer>();

            List<IBuyer> byers = new List<IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens.Length == 4)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    string birthdate = tokens[3];

                    byersByName[name] = new Citizen(name, age, id, birthdate);
                }
                else
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string group = tokens[2];

                    byersByName[name] = new Rebel(name, age, group);
                }
            }


            while (true)
            {
                string nameOfByer = Console.ReadLine();

                if (nameOfByer == "End")
                {
                    break;
                }

                if (!byersByName.ContainsKey(nameOfByer))
                {
                    continue;
                }
                else
                {
                    IBuyer buyer = byersByName[nameOfByer];
                    buyer.BuyFood();

                }

            }

            var totalFood = 0;

            foreach (var kvp in byersByName)
            {
                totalFood += kvp.Value.Food;
            }
            Console.WriteLine(totalFood);




        }
    }
}