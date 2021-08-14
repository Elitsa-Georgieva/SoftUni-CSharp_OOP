using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public IRace GetByName(string name) => this.races.FirstOrDefault(x => x.Name == name);

        public IReadOnlyCollection<IRace> GetAll() => this.races.ToArray();

        public void Add(IRace model) => this.races.Add(model);

        public bool Remove(IRace model) => this.races.Remove(model);
    }
}
