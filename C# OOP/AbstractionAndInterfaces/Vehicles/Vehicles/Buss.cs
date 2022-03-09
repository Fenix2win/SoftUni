using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Buss : IVehicle
    {
        private double fuelQuantity;

        public Buss(double capacity, double fuelQuantity, double consumption)
        {
            FuelQuantity = fuelQuantity;
            Consumption = consumption;
            Capacity = capacity;

        }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public double Capacity { get; private set; }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set
            {
                if (value > Capacity)
                {
                    fuelQuantity = 0;
                }

                this.fuelQuantity = value;
            }
        }
        public double Consumption { get; set; }
        public bool IsEmpty { get; set; }

        public void Drive(double distance)
        {
            if (!IsEmpty) Consumption += 1.4;

            double neededFuel = distance * (Consumption);
            if (FuelQuantity < neededFuel)
            {
                Console.WriteLine("Bus needs refueling");
            }
            else
            {
                Console.WriteLine($"Bus travelled {distance} km");
                FuelQuantity -= neededFuel;
            }
        }
        

        public void Refuel(double liters)
        {
            if (liters<=0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            double emptySpace = Capacity - fuelQuantity;
            if (emptySpace >= liters) FuelQuantity += liters;
            else Console.WriteLine($"Cannot fit {liters} fuel in the tank");
        }
    }
}
