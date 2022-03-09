using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid : BaseHero,IHero
    {
        private  readonly string _type;
        private string _name;
        private readonly int _power;

        public Druid(string name)
        {
            Name = name;
            _type = "Druid";
            _power =80;
        }
        
        public override string Type
        {
            get { return _type; }
            
        }

        public override string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override int Power
        {
            get { return _power; }
           
        }

        public override string ToString()
        {
            return $"{Type} - {Name} healed for {Power}";
        }
       
    }
}
