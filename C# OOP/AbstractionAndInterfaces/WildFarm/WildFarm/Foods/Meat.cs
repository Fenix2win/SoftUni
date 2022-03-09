using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Foods
{
    public class Meat:Food
    {
        public Meat(int quantity, string foodType) : base(quantity, foodType)
        {

        }

        public override bool IsForThisAnimal(string animal)
        {
            if (animal == "Hen" || animal == "Cat" || animal == "Tiger" || animal == "Dog"||animal=="Owl")
            {
                return true;
            }
            return false;
        }
    }
}
