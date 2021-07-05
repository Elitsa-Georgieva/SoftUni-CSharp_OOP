using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Person person;
            if (age <= 15)
            {
                person = new Child(name, age);
                //Console.WriteLine(child);
            }
            else
            {
                person = new Person(name, age);
                //Console.WriteLine(person);
            }

            Console.WriteLine(person);
            

        }
    }
}