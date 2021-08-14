using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driverRepository;
        private readonly IRepository<ICar> carRepository;
        private readonly IRepository<IRace> raceRepository;
        public ChampionshipController()
        {
            driverRepository = new DriverRepository();
            carRepository = new CarRepository();
            raceRepository = new RaceRepository();
        }
        public string CreateDriver(string driverName)
        {
            var driverExists = driverRepository.GetByName(driverName);
            if (driverExists != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            var driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            var carExists = carRepository.GetByName(model);
            if (carExists != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            ICar car = null;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }
            else if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            carRepository.Add(car);

            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if (raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            var race = new Race(name, laps);

            raceRepository.Add(race);
            return $"Race {name} is created.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = raceRepository.GetByName(raceName);
            var driver = driverRepository.GetByName(driverName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var car = carRepository.GetByName(carModel);
            var driver = driverRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);

            carRepository.Remove(car); //CHECK "IS THAT NECESSARY"!!!!!!!!!!!!!!

            return $"Driver {driverName} received car {carModel}.";
        }

        public string StartRace(string raceName)
        {
            var race = raceRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw  new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            //сортираме драйвърите, на всеки драйвър взимаме колата и в колата да извикаме CalculateRacePoints(), което ще иска брой обилколки,
            //всеки рейс държи инфо колко обиколки трябва да се направят - race.Laps
            var drivers = race.Drivers            
                .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).Take(3).ToList();

            var first = drivers[0];
            var second = drivers[1];
            var third = drivers[2];

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Driver {first.Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {second.Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {third.Name} is third in {race.Name} race.");

            var result = sb.ToString().TrimEnd();

            raceRepository.Remove(race);

            return result;
        }
    }
}
