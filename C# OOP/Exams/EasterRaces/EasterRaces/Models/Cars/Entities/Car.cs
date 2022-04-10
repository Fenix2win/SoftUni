using EasterRaces.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private int minHorsePower;
        private int maxHorsePower;
        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            Model = model;
            HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value)||value.Length<4)
                {
                    throw new ArgumentException($"Model {model} cannot be less than 4 symbols.");
                }
                model = value;
            }
        }
        public int HorsePower
        {
            get => horsePower;
            private set
            {
                if (value<this.minHorsePower||value>maxHorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                horsePower = value;
            }
        }

        public double CubicCentimeters { get;private set; }

        public double CalculateRacePoints(int laps)
        {
            double racePoints = CubicCentimeters / HorsePower * laps;
            return racePoints;
        }
    }
}
