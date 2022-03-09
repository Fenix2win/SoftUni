using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Mouse:Mammal
    {
        public Mouse(string name, double weight,  string livingRegion) : base(name, weight, livingRegion)
        {

        }

        public int FoodEaten { get; set; }
        public override void FoodAsking()
        {
            Console.WriteLine("Squeak");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {FoodEaten}]";
        }
        public override void Feed(Food food)
        {
            if (food.IsForThisAnimal("Mouse"))
            {
                Weight += food.Quantity * 0.1;
                FoodEaten = food.Quantity;

            }
            else
            {
                Console.WriteLine($"Mouse does not eat {food.FoodType}!");
            }
        }
    }
}
