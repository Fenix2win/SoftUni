using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Foods
{
    public class Seed:Food
    {
        public Seed(int quantity, string foodType) : base(quantity, foodType)
        {

        }

        public override bool IsForThisAnimal(string animal)
        {
            if (animal == "Hen" )
            {
                return true;
            }
            return false;
        }
    }
}
