using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public interface IVehicle
    {
        public  double FuelQuantity { get; set; }
        public double Consumption { get; set; }
        public bool IsEmpty { get; set; }

        public void Drive(double distance);
        public void Refuel(double liters);
    }
}
