﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Warrior:BaseHero
    {
        private readonly string _type;
        private string _name;
        private readonly int _power;

        public Warrior(string name)
        {
            Name = name;
            _type = "Warrior";
            _power = 100;
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
            return $"{Type} - {Name} hit for {Power} damage";
        }
    }
}
