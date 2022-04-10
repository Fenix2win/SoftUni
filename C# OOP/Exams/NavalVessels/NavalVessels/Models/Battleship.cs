using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Contracts
{
    public class Battleship : Vessel, IBattleship
    {

        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, 300)
        {
            SonarMode = false;
        }

        public bool SonarMode  { get; set; }

        string sonarStatus = "OFF";
        public void ToggleSonarMode()
        {
            if (SonarMode)
            {
                SonarMode = false;
                MainWeaponCaliber -= 40;
                Speed -= 5;
                sonarStatus = "OFF";
            }
            else
            {
                SonarMode = true;
                MainWeaponCaliber += 40;
                Speed += 5;
                sonarStatus = "ON";
            }
        }

        public override void RepairVessel()
        {
            ArmorThickness=300;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine( base.ToString());
            sb.AppendLine($" *Sonar mode: {sonarStatus}");
            
            return sb.ToString().TrimEnd();
        }
    }
}
