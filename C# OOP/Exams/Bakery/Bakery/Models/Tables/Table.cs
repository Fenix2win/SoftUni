using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
            IsReserved = false;
        }

        public IReadOnlyCollection<IBakedFood> FoodOrders { get { return foodOrders; } }
        public IReadOnlyCollection<IDrink> DrinkOrders { get { return drinkOrders; } }
        public int TableNumber { get; set; }

        public int Capacity
        {
            get => capacity;
          private  set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                capacity = value;
            }
        }

        public int NumberOfPeople 
        { 
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price { get=> PricePerPerson*NumberOfPeople;  }

        public void Clear()
        {
            IsReserved = false;
            foodOrders.Clear();
            drinkOrders.Clear();
        }

        public decimal GetBill()
        {
            decimal foodSum = 0;
            decimal drinkSum = 0;
            foreach (var food in FoodOrders)
            {
                foodSum += food.Price;
            }
            foreach (var drink in DrinkOrders)
            {
                drinkSum+=drink.Price;
            }
            decimal total=(foodSum+drinkSum)+(NumberOfPeople*PricePerPerson);
            return total;
        }

        public abstract string GetFreeTableInfo();
       

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
           foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
           IsReserved = true;
        }
    }
}
