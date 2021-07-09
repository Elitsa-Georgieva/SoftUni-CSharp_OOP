namespace _06.FoodShortage.Interfaces
{
    public interface IPerson : IBuyer
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
