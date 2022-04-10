using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {

        private List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models { get => cars; }
       

        public void Add(ICar model)
        {
            if (cars.Contains(model))
            {
                throw new ArgumentException($"Car {model} is already create.");
            }
            
            cars.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return Models;
        }

        public ICar GetByName(string name)
        {
            return cars.Where(x=>x.Model==name).FirstOrDefault();
        }

        public bool Remove(ICar model)
        {
          return cars.Remove(model);
        }
    }
}
