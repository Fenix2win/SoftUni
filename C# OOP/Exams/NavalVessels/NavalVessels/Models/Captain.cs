using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Contracts
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            FullName = fullName;
            CombatExperience = 0;
            Vessels=new List<IVessel>();
        }

        public string FullName
        {
            get => fullName;
            private set
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }
                fullName = value;
            }
        }

        public int CombatExperience { get;private set; }

        public ICollection<IVessel> Vessels { get;}

        public void AddVessel(IVessel vessel)
        {
            if (vessel==null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }
            else
            {
                Vessels.Add(vessel);
            }
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
           
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");
          
            if (Vessels.Count>0)
            {
                foreach (var vessel in Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
