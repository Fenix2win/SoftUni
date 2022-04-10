using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Contracts
{
    public class Submarine : Vessel,ISubmarine
    {
        public Submarine(string name, double mainWeaponCaliber, double speed) : 
            base(name, mainWeaponCaliber, speed, 200)
        {
            SubmergeMode= false;
        }

        public bool SubmergeMode  { get; set; }

        public override void RepairVessel()
        {
           ArmorThickness=200;
        }

        string submergeModeStatus = "OFF";
        public void ToggleSubmergeMode()
        {
            if(SubmergeMode)
            {
                SubmergeMode = false;
                MainWeaponCaliber -= 40;
                Speed -= 4;
                submergeModeStatus = "OFF";
            }
            else
            {
                SubmergeMode = true;
                MainWeaponCaliber += 40;
                Speed += 4;
                submergeModeStatus = "ON";
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {submergeModeStatus}");
            return sb.ToString().TrimEnd();
        }
    }
}
