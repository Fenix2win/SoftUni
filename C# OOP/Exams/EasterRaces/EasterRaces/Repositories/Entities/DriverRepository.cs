using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{

    public class DriverRepository : IRepository<IDriver>
    {
        protected List<IDriver> drivers;

        public DriverRepository()
        {
            drivers = new List<IDriver>();
        }
        public IReadOnlyCollection<IDriver> Models { get => drivers; }
        public void Add(IDriver model)
        {
            drivers.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return Models;
        }

        public IDriver GetByName(string name)
        {
            return drivers.Where(x=>x.Name==name).FirstOrDefault();
        }

        public bool Remove(IDriver model)
        {
           return drivers.Remove(model);
        }
    }
}
