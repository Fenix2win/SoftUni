using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero:IHero
    {
        public abstract string Type { get;}
        public abstract string Name { get; set; }
        public abstract int Power { get; }
        
       
    }
}
