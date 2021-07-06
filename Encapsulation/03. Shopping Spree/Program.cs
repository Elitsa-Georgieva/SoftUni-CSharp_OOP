using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                string[] personsInfo = Console.ReadLine().Split(';');
                for (int i = 0; i < personsInfo.Length; i++)
                {
                    string[] parts = personsInfo[i].Split('=');
                    string name = parts[0];
                    decimal money = decimal.Parse(parts[1]);

                    Person person = new Person(name, money);
                    persons.Add(person);
                }

                string[] productInfo = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < productInfo.Length; i++)
                {
                    string[] parts = productInfo[i].Split('=');
                    string name = parts[0];
                    decimal price = decimal.Parse(parts[1]);

                    Product product = new Product(name, price);
                    products.Add(product);
                }

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] command = input.Split(" ");

                string personName = command[0];
                string productName = command[1];

                Person currPerson = persons.FirstOrDefault(p => p.Name == personName);
                Product currProduct = products.FirstOrDefault(p => p.Name == productName);
                
                currPerson.AddProduct(currProduct, currPerson);

                
            }
            foreach (Person person in persons)
            {
                if (!person.BagOfProducts.Any())
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                    continue;
                }

                Console.WriteLine($"{person.Name} - {string.Join(", ", person.BagOfProducts)}");
            }
        }
    }
}
