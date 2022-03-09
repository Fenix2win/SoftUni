using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] carInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double carFuel=double.Parse(carInfo[1]);
            double carCapacity=double.Parse(carInfo[3]);
            if (carFuel > carCapacity) carFuel = 0;
           
            string[] truckInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            double truckFuel = double.Parse(truckInfo[1]);
            double truckCapacity = double.Parse(truckInfo[3]);
            if (truckFuel > truckCapacity) truckFuel = 0;

            string[] bussInfo = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double busFuel = double.Parse(bussInfo[1]);
            double busCapacity = double.Parse(bussInfo[3]);
            if (busFuel > busCapacity) busFuel = 0;

            IVehicle car = new Car(carCapacity, carFuel,double.Parse(carInfo[2]));
            IVehicle truck = new Truck(truckCapacity,truckFuel, double.Parse(truckInfo[2]));
            IVehicle buss = new Buss(busCapacity, busFuel, double.Parse(bussInfo[2]));
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                string action = command[0];
                string vehicle = command[1];
                double value = double.Parse(command[2]);

                if (vehicle == "Car")
                {
                    if (action == "Drive") car.Drive(value);
                    else if (action == "Refuel") car.Refuel(value);
                }
                else if (vehicle == "Truck")
                {
                    if (action == "Drive") truck.Drive(value);
                    else if (action == "Refuel") truck.Refuel(value);
                }
                else if (vehicle=="Bus")
                {
                    if (action == "Drive")
                    {
                        buss.IsEmpty = false;
                        buss.Drive(value);
                    }
                    else if (action == "Refuel") buss.Refuel(value);
                   
                    else if (action == "DriveEmpty")
                    {
                        buss.IsEmpty = true;
                        buss.Drive(value);
                    }
                }

            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {buss.FuelQuantity:f2}");


        }
    }
}
