using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    internal class Cat:Feline
    {
        public Cat(string name, double weight,  string livingRegion,string breed) : base(name, weight,livingRegion,breed)
        {

        }

        public double FoodEaten { get; set; }

        public override void FoodAsking()
        {
            Console.WriteLine("Meow");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {FoodEaten}]";
        }

        public override void Feed(Food food)
        {
            if (food.IsForThisAnimal("Cat"))
            {
                Weight += food.Quantity * 0.3;
                FoodEaten = food.Quantity;
            }
            else
            {
                Console.WriteLine($"Cat does not eat {food.FoodType}!");
            }
        }
    }
}
