using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IDriver> drivers;

        public Race(string name,int laps)
        {
            Name = name;
            Laps = laps;
            this.drivers = new List<IDriver>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentNullException($"Name {value} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }

        public int Laps
        {
            get => laps;
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentNullException("Laps cannot be less than 1.");
                }
                laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers { get => drivers; }

        public void AddDriver(IDriver driver)
        {
            if (driver==null)
            {
                throw new ArgumentException("Driver cannot be null.");
            }
          
            if (!driver.CanParticipate)
            {
                throw new ArgumentException($"Driver {driver.Name} could not participate in race.");
            }
          
            if (drivers.Contains(driver))
            {
                throw new ArgumentException("Driver {driver name} is already added in {race name} race.");
            }
        }
    }
}
