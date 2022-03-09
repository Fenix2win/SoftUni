using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : IVehicle
    {
        private double fuelQuantity;

        public Car(double capacity, double fuelQuantity, double consumption)
        {
            FuelQuantity = fuelQuantity;
            Consumption = consumption;
            Capacity = capacity;
            
        }

        public double Capacity { get; set; }
        public  double FuelQuantity
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
            double neededFuel = distance * (Consumption + 0.9);
            if (FuelQuantity<neededFuel)
            {
                Console.WriteLine("Car needs refueling");
            }
            else
            {
                Console.WriteLine($"Car travelled {distance} km");
                FuelQuantity-=neededFuel;
            }
        }

        public void Refuel(double liters)
        {

            if (liters <= 0)
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
