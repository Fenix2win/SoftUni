using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] personInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            string[] productInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            List<Product> products = new List<Product>();
            Dictionary<string, Person> persons = new Dictionary<string, Person>();

            Person per = new Person();

            try
            {


                for (int i = 0; i < personInput.Length; i++)
                {
                    string[] personInfo = personInput[i].Split("=");
                    string name = personInfo[0];
                    int money = int.Parse(personInfo[1]);

                    Person person = new Person(name, money);

                    persons.Add(name, person);
                }

                for (int i = 0; i < productInput.Length; i++)
                {
                    string[] productInfo = productInput[i].Split("=");
                    string name = productInfo[0];
                    int cost = int.Parse(productInfo[1]);

                    Product product = new Product(name, cost);

                    products.Add(product);
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] cmd = command.Split(" ");
                    string name = cmd[0];
                    string product = cmd[1];


                    Product currProduct = products.Where(x => x.Name == product).FirstOrDefault();

                    if (persons[name].Money - currProduct.Cost < 0)
                    {
                        Console.WriteLine($"{name} can't afford {product}");
                    }
                    else
                    {
                        persons[name].BuyProduct(currProduct);
                        persons[name].Money -= currProduct.Cost;
                        Console.WriteLine($"{name} bought {product}");
                    }


                    command = Console.ReadLine();
                }



                foreach (var person in persons)
                {
                    if (person.Value.bagOfProducts.Count <= 0)
                    {
                        Console.WriteLine($"{person.Key} - Nothing bought ");
                    }
                    else
                    {

                        Console.WriteLine($"{person.Key} - {string.Join(", ", person.Value.bagOfProducts.Select(x => x.Name))}");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
