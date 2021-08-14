using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public class DriverRepository : IRepository<IDriver>

    {
    private readonly List<IDriver> races;

    public DriverRepository()
    {
        this.races = new List<IDriver>();
    }

    public IDriver GetByName(string name) => this.races.FirstOrDefault(x => x.Name == name);

    public IReadOnlyCollection<IDriver> GetAll() => this.races.ToArray();

    public void Add(IDriver model) => this.races.Add(model);

    public bool Remove(IDriver model) => this.races.Remove(model);
    }
}
