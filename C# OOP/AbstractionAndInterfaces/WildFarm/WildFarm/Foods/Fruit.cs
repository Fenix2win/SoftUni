using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Foods
{
    public class Fruit:Food
    {
        public Fruit(int quantity,string foodType) : base(quantity,foodType)
        {

        }

        public override bool IsForThisAnimal(string animal)
        {
            if (animal=="Hen"||animal=="Mouse")
            {
                return true;
            }
            return false;
        }
    }
}
