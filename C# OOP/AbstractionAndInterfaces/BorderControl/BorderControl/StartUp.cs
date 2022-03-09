using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");

                if (input.Length == 4)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthday = input[3];

                    IBuyer buyer = new Citizen(name, age, id, birthday, 0);
                    buyers.Add(buyer);
                }
                else if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    IBuyer rebel = new Rebel(name, age, group, 0);
                    buyers.Add(rebel);
                }
            }

            string nameInput = Console.ReadLine();
            while (nameInput != "End")
            {
                var currBuyer = buyers.Where(x => x.Name == nameInput).FirstOrDefault();

                if (currBuyer != null) currBuyer.BuyFood();



                nameInput = Console.ReadLine();
            }

            int sum = 0;
            foreach (var item in buyers)
            {
                sum += item.Food;
            }
            Console.WriteLine(sum);
        }
    }
}
