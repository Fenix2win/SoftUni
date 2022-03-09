using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Tiger:Feline
    {
        enum food
        {
            meat
        }


        public Tiger(string name, double weight,string livingRegion, string breed) : base(name, weight,  livingRegion, breed)
        {

        }
        public override void FoodAsking()
        {
            Console.WriteLine("ROAR!!!");
        }

        public int FoodEaten { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, {FoodEaten}]";
        }
        public override void Feed(Food food)
        {
            if (food.IsForThisAnimal("Tiger"))
            {
                Weight += food.Quantity * 1;
                FoodEaten = food.Quantity;

            }
            else
            {
                Console.WriteLine($"Tiger does not eat {food.FoodType}!");
            }
        }
    }
}
