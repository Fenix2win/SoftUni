using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double DefaultGrams = 10;
        
        public Fish(string name, decimal price) : base(name, price, DefaultGrams)
        {
        }

    }
}
