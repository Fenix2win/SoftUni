using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Food
    {
        protected Food(int quantity,string foodtype)
        {
            Quantity = quantity;
            FoodType= foodtype;
        }

        public string FoodType { get; set; }
        public int Quantity { get; set; }

        public abstract bool IsForThisAnimal(string animal);
    }
}
