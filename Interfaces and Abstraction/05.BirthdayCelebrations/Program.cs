using System;
using System.Collections.Generic;
using System.Linq;
using _05.BirthdayCelebrations.Interfaces;
using _05.BirthdayCelebrations.Models;

namespace _05.BirthdayCelebrations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirth> withBirthdates = new List<IBirth>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] tokens = line.Split();
                string type = tokens[0];
                if (type == nameof(Citizen))
                {
                    string citizenName = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthDate = tokens[4];

                    withBirthdates.Add(new Citizen(citizenName, age, id, birthDate));
                }
                else if (type == nameof(Pet))
                {
                    string petName = tokens[1];
                    string birthDate = tokens[2];

                    withBirthdates.Add(new Pet(petName, birthDate));
                }

            }

            string year = Console.ReadLine();

            List<IBirth> bornInYear = withBirthdates.Where(x => x.Birthdate.EndsWith(year)).ToList();

            foreach (var birthDate in bornInYear)
            {
                Console.WriteLine(birthDate.Birthdate);
            }
        }
    }
}
