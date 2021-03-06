using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Contracts
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
       
        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            ArmorThickness= armorThickness;
            MainWeaponCaliber= mainWeaponCaliber;
            Speed= speed;
            Targets = new List<string>();
            

        }

        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
            set
            {
                if(value == null)
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }
                captain = value;
            }
        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; internal set; }

        public double Speed { get; internal set; }

        public ICollection<string> Targets { get; set; }

       

        public void Attack(IVessel target)
        {
            if (target==null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }
            else
            {
                target.ArmorThickness -= this.MainWeaponCaliber;
                
                if (target.ArmorThickness < 0) target.ArmorThickness = 0;
               
                Targets.Add(target.Name);
            }

        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
           
            sb.AppendLine($" *Armor thickness: { ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
           
            if (Targets.Count>0)
            {
            sb.AppendLine($" *Targets: {String.Join(", ", Targets)}");
            }
           
            else
            {
                sb.AppendLine($" *Targets: None");

            }
            
            return sb.ToString().TrimEnd();
            
        }

    }
}




