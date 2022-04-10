﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public class InsideTable : Table
    {
        public InsideTable(int tableNumber, int capacity) : base(tableNumber, capacity, 2.5m)
        {
        }

        public override string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson:f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
