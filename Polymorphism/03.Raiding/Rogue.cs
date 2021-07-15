﻿namespace _03.Raiding
{
    public class Rogue : Hero
    {
        private const int power = 80;
        public Rogue(string name)
            : base(name, power)
        {
        }
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }


    }
}
