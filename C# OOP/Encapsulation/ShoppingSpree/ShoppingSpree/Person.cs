using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        public List<Product> bagOfProducts;


        private string name;
        private int money;

        public Person()
        {

        }
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }


        public string Name
        {
            get { return name; }
            private set 
            {
                if (value==null||value.Length==0||value==" ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value; 
            }
        }


        public int Money
        {
            get { return money; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value; 
            }
        }

       
        public void BuyProduct(Product product)
        {
            bagOfProducts.Add(product); 
        }
       

        //public void BuyProduct(Person person, Product product)
        //{
        //    if (person.Money<product.Cost)
        //    {
        //        Console.WriteLine($"{person.Name} can't afford {product}");
        //    }
        //    else
        //    {
        //        if (!bagOfProducts.ContainsKey(person))
        //        {
        //            bagOfProducts.Add(person, new List<string>());
        //        }
        //        person.Money-=product.Cost;
        //        bagOfProducts[person].Add(product.Name);
        //        Console.WriteLine($"{person.Name} bought {product.Name}");
        //    }
        //}


       
    }
}
