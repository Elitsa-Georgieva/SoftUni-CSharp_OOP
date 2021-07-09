using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using _04.BorderControl.Interfaces;
using _04.BorderControl.Models;

namespace _04.BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IIdentifier> identifiers = new List<IIdentifier>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] tokens = line.Split().ToArray();

                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    Citizen citizen = new Citizen(name, age, id);

                    identifiers.Add(citizen);
                }
                else
                {
                    string model = tokens[0];
                    string id = tokens[1];

                    Robot robot = new Robot(model, id);

                    identifiers.Add(robot);
                }

            }

            string endOfId = Console.ReadLine();

            List<IIdentifier> identifiersDetained = identifiers.Where(x => x.Id.EndsWith(endOfId)).ToList();

            foreach (var id in identifiersDetained)
            {
                Console.WriteLine(id.Id);
            }
        }
    }
}
