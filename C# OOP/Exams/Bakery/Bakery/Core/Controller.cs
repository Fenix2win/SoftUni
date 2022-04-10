using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private readonly List<ITable> tables;
        decimal totalIncom = 0;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public IReadOnlyCollection<IBakedFood> BakedFoods { get => bakedFoods; }
        public IReadOnlyCollection<IDrink> Drinks { get => drinks; }
        public IReadOnlyCollection<ITable> Tables { get => tables; }


        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }
            drinks.Add(drink);
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Cake(name, price);
            }

            if (food != null)
            {
                bakedFoods.Add(food);
                return $"Added {name} ({type}) to the menu";
            }
            return null;
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            tables.Add(table);
            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = tables.Where(x => x.IsReserved == false).ToList();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var table in freeTables)
            {

                stringBuilder.AppendLine(table.GetFreeTableInfo());
              
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {totalIncom:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = Tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();
            decimal sum = table.GetBill();
            totalIncom += sum;
            table.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {sum:f2}");

            return sb.ToString().TrimEnd();

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = Tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();
            if (table == null) return $"Could not find table {tableNumber}";

            var drink = drinks.Where(x => x.Name == drinkName).Where(x => x.Brand == drinkBrand).FirstOrDefault();
            if (drink == null) return $"There is no {drinkName} {drinkBrand} available";

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = Tables.Where(x => x.TableNumber == tableNumber).FirstOrDefault();
            if (table == null) return $"Could not find table {tableNumber}";

            var food = BakedFoods.Where(x => x.Name == foodName).FirstOrDefault();
            if (food == null) return $"No {foodName} in the menu";

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var table = tables.Where(x => x.IsReserved == false).Where(x => x.Capacity >= numberOfPeople).FirstOrDefault();
            if (table == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            table.Reserve(numberOfPeople);

            return $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
