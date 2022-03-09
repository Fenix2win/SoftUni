using System;
using System.Collections.Generic;
using WildFarm.Foods;

namespace WildFarm
{


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            Animal animal = null;
            Food foodForFeed = null;

            int count = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;

                string[] animalInput = input.Split(' ');
                string type = animalInput[0];
                string name = animalInput[1];
                double weight = double.Parse(animalInput[2]);

                string[] foodInput = Console.ReadLine().Split(' ');
                string animalType = animalInput[0];
                if (animalType == "Cat")
                {
                    string region = animalInput[3];
                    string breed = animalInput[4];

                    animal = new Cat(name, weight, region, breed);
                    animals.Add(animal);
                }
                else if (animalType == "Dog")
                {
                    string region = animalInput[3];
                    animal = new Dog(name, weight, region);
                    animals.Add(animal);
                }
                else if (animalType == "Hen")
                {
                    double wingSize = double.Parse(animalInput[3]);
                    animal = new Hen(name, weight, wingSize);
                    animals.Add(animal);
                }
                else if (animalType == "Mouse")
                {
                    string region = animalInput[3];

                    animal = new Mouse(name, weight, region);
                    animals.Add(animal);

                }
                else if (animalType == "Owl")
                {
                    double wingSize = double.Parse(animalInput[3]);

                    animal = new Owl(name, weight, wingSize);
                    animals.Add(animal);
                }
                else if (animalType == "Tiger")
                {
                    string region = animalInput[3];
                    string breed = animalInput[4];

                    animal = new Tiger(name, weight, region, breed);
                    animals.Add(animal);

                }

                string foodType = foodInput[0];
                int foodQtty = int.Parse(foodInput[1]);

                switch (foodType)
                {
                    case "Fruit":
                        foodForFeed = new Fruit(foodQtty,foodType);
                        break;
                    case "Meat":
                      foodForFeed = new Meat(foodQtty, foodType);
                        break;
                    case "Vegetable":
                   foodForFeed = new Vegetable(foodQtty, foodType);
                        break;
                    case "Seed":
                    foodForFeed = new Fruit(foodQtty, foodType);
                        break;
                }
                animal.FoodAsking();
                animal.Feed(foodForFeed);

            }

            foreach (var item in animals)
            {
                Console.WriteLine(item);
            }
           
        }
    }
}
