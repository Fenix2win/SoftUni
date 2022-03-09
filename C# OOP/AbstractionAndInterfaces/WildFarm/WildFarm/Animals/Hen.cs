using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public class Hen:Bird
    {
        public Hen(string name, double weight,  double wingSize) : base(name, weight,  wingSize)
        {
                
        }
        public override void FoodAsking()
        {
            Console.WriteLine("Cluck");
        }

        public int FoodEaten { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, {FoodEaten}]";
        }
        public override void Feed(Food food)
        {
            if (food.IsForThisAnimal("Hen"))
            {
                Weight += food.Quantity * 0.35;
                FoodEaten = food.Quantity;

            }
            else
            {
                Console.WriteLine($"Hen does not eat {food.FoodType}!");
            }
        }
    }
}
