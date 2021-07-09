namespace _05.BirthdayCelebrations.Interfaces
{
    public interface ICitizen : IIdentifier, IBirth
    {
        public string Name { get;}

        public int Age { get;}

        
    }
}
