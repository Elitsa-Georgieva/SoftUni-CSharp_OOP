using _04.WildFarm.Models.Food.Contracts;

namespace _04.WildFarm.Models.Animal.Contracts
{
    public interface IAnimal
    {
        public string Name { get; }

        public double Weight { get; }

        public int FoodEaten { get;}

        string ProduceSound();

        void Feed(IFood food);


    }
}
