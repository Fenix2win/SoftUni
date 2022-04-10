using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Core.Contracts
{
    public class Controller : IController
    {
        private VesselRepository vessels;
        private List<ICaptain> captains;

        public Controller()
        {

            vessels = new VesselRepository();
            captains = new List<ICaptain>();
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            var searchCapitan = captains.
                Where(x=>x.FullName == selectedCaptainName).FirstOrDefault();
           
            if (searchCapitan == null) return $"Captain {selectedCaptainName} could not be found.";
            
            var searchVessel = vessels.Models.
                Where(x => x.Name == selectedVesselName).FirstOrDefault();
            
            if (searchVessel == null) return $"Vessel {selectedVesselName} could not be found.";

            if (searchVessel.Captain != null) return $"Vessel {selectedVesselName} is already occupied.";

            searchVessel.Captain = searchCapitan;
            searchCapitan.AddVessel(searchVessel);

            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";


        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attackingVessel = vessels.Models.
                Where(x => x.Name == attackingVesselName).FirstOrDefault();

            var defendingVessel = vessels.Models.
                Where(x => x.Name == defendingVesselName).FirstOrDefault();

            if (attackingVessel==null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }
            if (defendingVessel==null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }

            if (attackingVessel.ArmorThickness==0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }
            if (defendingVessel.ArmorThickness==0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";

            }

            attackingVessel.Attack(defendingVessel);
            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defendingVessel.ArmorThickness}.";
        }

        public string CaptainReport(string captainFullName)
        {
            var searchCapitan = captains.
                Where(x=>x.FullName == captainFullName).FirstOrDefault();

            return searchCapitan.Report();

        }

        public string HireCaptain(string fullName)
        {
            var searchCapitan = captains.
                Where(x=>x.FullName == fullName).FirstOrDefault();
            if (searchCapitan == null)
            {
                ICaptain capitan=new Captain(fullName);
                captains.Add(capitan);
                return $"Captain {fullName} is hired.";
            }
            return $"Captain {fullName} is already hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            var searchVessel= vessels.Models. 
                Where(x=>x.Name==name).FirstOrDefault();

            if (searchVessel!=null)
            {
                return $"{searchVessel.GetType().Name} vessel {name} is already manufactured.";
            }

            if (vesselType== "Submarine")
            {
                var subMarine = new Submarine(name, mainWeaponCaliber, speed);
                vessels.Add(subMarine);
            }
            
            else if (vesselType == "Battleship")
            {
                var battleship = new Battleship(name, mainWeaponCaliber, speed);
                vessels.Add(battleship);
            }

            else
            {
                return "Invalid vessel type.";
            }
            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";

            

        }

        public string ServiceVessel(string vesselName)
        {
            var searchVessel = vessels.Models.
                Where(x => x.Name == vesselName).FirstOrDefault();
            
            if (searchVessel!=null)
            {
                searchVessel.RepairVessel();
                return $"Vessel {vesselName} was repaired.";
            }
            return $"Vessel {vesselName} could not be found.";
        }

        public string ToggleSpecialMode(string vesselName)
        {
            var searchVessel = vessels.Models.
                Where(x => x.Name == vesselName).FirstOrDefault();

            if (searchVessel!=null)
            {
                if (searchVessel.GetType().Name== "Battleship")
                {
                    Battleship battleShip =(Battleship)searchVessel;
                    battleShip.ToggleSonarMode();
                    return $"Battleship {vesselName} toggled sonar mode.";
                }
                
                else if (searchVessel.GetType().Name == "Submarine")
                {
                    Submarine submarine = (Submarine)searchVessel;
                    submarine.ToggleSubmergeMode();
                    return $"Submarine {vesselName} toggled submerge mode.";
                }
            }
               
            return $"Vessel {vesselName} could not be found.";


        }

        public string VesselReport(string vesselName)
        {
            var searchVessel = vessels.Models.Where(x => x.Name == vesselName).FirstOrDefault();
            return searchVessel.ToString();

        }
    }
}
