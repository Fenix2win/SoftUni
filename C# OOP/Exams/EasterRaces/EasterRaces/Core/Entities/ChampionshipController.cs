using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository drivers;
        private CarRepository cars;
        private RaceRepository races;

        public ChampionshipController()
        {
            drivers = new DriverRepository();
            cars = new CarRepository();
            races = new RaceRepository();
        }

       

        public DriverRepository Drivers { get => drivers; }

        public  CarRepository Cars { get=>cars; }
        public RaceRepository Races { get=>races; }

        public string AddCarToDriver(string driverName, string carModel)
        {
            var driver = drivers.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }
            var car = cars.GetByName(carModel);
            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            var race = races.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            var driver = drivers.GetByName(driverName);
            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);
            return $"Driver {driverName} added in {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            var car = cars.GetByName(model);
           
            ICar newCar = null;
           
            if (car == null)
            {
                if (type == "Muscle")
                {
                    newCar = new MuscleCar(model, horsePower);
                }
                if (type == "Sports")
                {
                    newCar = new SportsCar(model, horsePower);
                }
                
                cars.Add(newCar);
                
                return $"{GetType().Name} {model} is created.";
            }
            
            return $"Car {model} is already created.";
        }

        public string CreateDriver(string driverName)
        {
            var driver = drivers.GetByName(driverName);
           
            
            if (driver != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }
           
            var newDriver = new Driver(driverName);
           
            drivers.Add(newDriver);
           
            return $"Driver {driverName} is created.";

        }

        public string CreateRace(string name, int laps)
        {
            var race = races.GetByName(name);
           
            if (race != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            var newRace=new Race(name, laps);
           
            races.Add(newRace);
           
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = races.GetByName(raceName);
            
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
          
            List<IDriver> raceDrivers = new List<IDriver>();
          
            foreach (var driver in drivers.Models)
            {
                if (driver.CanParticipate) raceDrivers.Add(driver);
            }

           
            if (raceDrivers.Count<3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }
            
            raceDrivers=raceDrivers.OrderByDescending(x=>x.Car.CalculateRacePoints(race.Laps)).
                ThenBy(x=>x.Name).Take(3).ToList();

            StringBuilder sb=new StringBuilder();
           
            int count=0;
           
            foreach (var driver in raceDrivers)
            {
                count++;
                
                if (count == 1) sb.AppendLine($"Driver {driver.Name} wins {raceName} race.");
                if (count == 2) sb.AppendLine($"Driver {driver.Name} is second in {raceName} race.");
                if (count == 3) sb.AppendLine($"Driver {driver.Name} is third in {raceName} race.");
            }
          
            return sb.ToString().TrimEnd();   
        }
    }
}
