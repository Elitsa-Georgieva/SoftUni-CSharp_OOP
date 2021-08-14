using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Drivers
{
    public class Driver : IDriver
    {
        private string name;

        public Driver(string name)
        {
            Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                this.name = value;
            }
        }

        public ICar Car { get; private set; }
        public int NumberOfWins { get; private set; }
        public bool CanParticipate => this.Car != null;
        public void WinRace() => this.NumberOfWins++;

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(ICar), "Car cannot be null.");
            }

            this.Car = car;
        }
    }
}
