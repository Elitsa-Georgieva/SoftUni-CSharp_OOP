namespace _03.Raiding
{
    public abstract class Hero
    {
        public Hero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }
        public string Name { get; }

        public int Power { get; }

        public abstract string CastAbility();
    }
}
