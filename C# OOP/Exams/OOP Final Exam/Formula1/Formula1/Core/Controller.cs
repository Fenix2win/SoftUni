using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilots;
        private RaceRepository races;
        private FormulaOneCarRepository cars;

        public Controller()
        {
            pilots = new PilotRepository();
            races = new RaceRepository();
            cars = new FormulaOneCarRepository();
        }



        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot=pilots.FindByName(pilotName);
            var car=cars.FindByName(carModel);

            if (pilot == null)
            {
                throw new InvalidOperationException($"Pilot { pilotName } does not exist or has a car.");
            }
            else if (pilot.Car!=null)
            {
                throw new InvalidOperationException($"Pilot { pilotName } does not exist or has a car.");

            }
            else if (car==null)
            {
                throw new NullReferenceException($"Car { carModel } does not exist.");
            }

            pilot.AddCar(car);
            return $"Pilot { pilotName } will drive a {car.GetType().Name} { carModel } car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race=races.FindByName(raceName);
            var pilot=pilots.FindByName(pilotFullName);

            if (race == null)
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }
            else if (pilot == null)
            {
                throw new InvalidOperationException($"Can not add pilot { pilotFullName} to the race.");
            }
            else if (race.Pilots.Contains(pilot)||pilot.CanRace==false)
            {
                throw new InvalidOperationException($"Can not add pilot { pilotFullName} to the race.");

            }

            race.AddPilot(pilot);

            return $"Pilot { pilotFullName} is added to the { raceName } race.";

        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            var car=cars.FindByName(model);
            if (car != null)
            {
                throw new InvalidOperationException($"Formula one car { model } is already created.");
            }

            if (type == "Ferrari")
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
                cars.Add(car);
            }

            else if (type == "Williams")
            {
                car = new Williams(model, horsepower, engineDisplacement);
                cars.Add(car);
            }
            else
            {
                throw new InvalidOperationException($"Formula one car type { type } is not valid.");
            }

            return $"Car { type }, model { model } is created.";

        }

        public string CreatePilot(string fullName)
        {
            var pilot=pilots.FindByName(fullName);
            if (pilot != null)
            {
                throw new InvalidOperationException($"Pilot { fullName } is already created.");
            }
            pilot=new Pilot(fullName);

            pilots.Add(pilot);
            return $"Pilot { fullName } is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var race=races.FindByName(raceName);
            if (race != null)
            {
                throw new InvalidOperationException($"Race { raceName } is already created.");
            }
            race=new Race(raceName, numberOfLaps);
            races.Add(race);

            return $"Race { raceName } is created.";
        }

        public string PilotReport()
        {
            var sortedPilots=pilots.Models.OrderByDescending(x=>x.NumberOfWins).ToList();

            StringBuilder sb=new StringBuilder();

            foreach (var pilot in sortedPilots)
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb=new StringBuilder();
            var executedRaces=races.Models.Where(x=>x.TookPlace).ToArray();

            foreach (var race in executedRaces)
            {
                sb.AppendLine(race.RaceInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            var race = races.FindByName(raceName);
            if (race==null)
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }
            else if (race.Pilots.Count<3)
            {
                throw new InvalidOperationException($"Race { raceName } cannot start with less than three participants.");
            }
            else if (race.TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race { raceName }.");
            }
           
            var winers=race.Pilots.
                OrderByDescending(x=>x.Car.RaceScoreCalculator(race.NumberOfLaps)).
                Take(3).ToArray();
            race.TookPlace = true;
            StringBuilder sb=new StringBuilder();
            
            
            var pilot1 = winers[0];
                pilot1.WinRace();
            var pilot2 = winers[1];
            var pilot3 = winers[2];
            sb.AppendLine($"Pilot { pilot1.FullName } wins the { raceName } race.");
            sb.AppendLine($"Pilot {  pilot2.FullName } is second in the { raceName } race.");
            sb.AppendLine($"Pilot { pilot3.FullName  } is third in the { raceName } race.");
            
            return sb.ToString().TrimEnd();
        }
    }
}
