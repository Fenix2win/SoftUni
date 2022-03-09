using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        public List<Product> products;

        private string name;
        private int cost;

        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (value == null || value.Length == 0 || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public int Cost
        {
            get { return cost; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value;
            }
        }


        
    }
}
