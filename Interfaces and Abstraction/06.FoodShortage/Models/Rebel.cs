using _06.FoodShortage.Interfaces;

namespace _06.FoodShortage.Models
{
    public class Rebel : IRebel, IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }
        public string Name { get; }
        public int Age { get; }
        public string Group { get; }
        public int Food { get; private set; } = 0;
        public void BuyFood()
        {
            Food += 5;
        }
    }
}
