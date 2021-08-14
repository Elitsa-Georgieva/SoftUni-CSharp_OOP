using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> races;

        public CarRepository()
        {
            this.races = new List<ICar>();
        }

        public ICar GetByName(string name) => this.races.FirstOrDefault(x => x.Model == name);

        public IReadOnlyCollection<ICar> GetAll() => this.races.ToArray();

        public void Add(ICar model) => this.races.Add(model);

        public bool Remove(ICar model) => this.races.Remove(model);
    }
}
