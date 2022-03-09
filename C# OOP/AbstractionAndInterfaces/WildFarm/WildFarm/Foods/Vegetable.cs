using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Foods
{
    public class Vegetable:Food
    {
        public Vegetable(int quantity, string foodType) : base(quantity, foodType)
        {

        }

        public override bool IsForThisAnimal(string animal)
        {
            if (animal == "Hen" || animal == "Cat" || animal == "Mause" )
            {
                return true;
            }
            return false;
        }
    }
}
