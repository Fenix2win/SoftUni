using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Dog:Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight,livingRegion)
        {

        }
        public int FoodEaten { get; set; }
        public override void FoodAsking()
        {
            Console.WriteLine("Woof!");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {FoodEaten}]";
        }
        public override void Feed(Food food)
        {
            if (food.IsForThisAnimal("Dog"))
            {
                Weight += food.Quantity * 0.4;
                FoodEaten = food.Quantity;

            }
            else
            {
                Console.WriteLine($"Dog does not eat {food.FoodType}!");
            }
        }
    }
}
