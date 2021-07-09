using _05.BirthdayCelebrations.Interfaces;

namespace _05.BirthdayCelebrations.Models
{
    public class Pet : IPet
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }
        public string Birthdate { get; private set; }
        public string Name { get; private set; }
    }
}
