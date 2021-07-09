namespace _06.FoodShortage.Interfaces
{
    public interface ICitizen : IIdentifier, IBirth
    {
        public string Name { get;}

        public int Age { get; }
    }
}
