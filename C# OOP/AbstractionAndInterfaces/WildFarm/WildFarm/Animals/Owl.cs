using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Owl:Bird
    {
        public Owl(string name, double weight,  double wingSize) : base(name, weight, wingSize)
        {

        }

        public int FoodEaten { get; set; }
        public override void FoodAsking()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {FoodEaten}]";
        }
        public override void Feed(Food food)
        {
            if (food.IsForThisAnimal("Owl"))
            {
                Weight += food.Quantity * 0.25;
                FoodEaten = food.Quantity;

            }
            else
            {
                Console.WriteLine($"Owl does not eat {food.FoodType}!");
            }
        }
    }
}
