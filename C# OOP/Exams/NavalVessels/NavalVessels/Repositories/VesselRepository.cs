using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> vessels;
        public VesselRepository()
        {
            vessels = new List<IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models { get => vessels; }

        public void Add(IVessel model)
        {
            vessels.Add(model);
        }

        public IVessel FindByName(string name)
        {
            return Models.Where(x=>x.Name == name).FirstOrDefault();    
        }

        public bool Remove(IVessel model)
        {
            var vessel = Models.Where(x=>x==model).FirstOrDefault();
            
            if (vessel != null) return false;
           
            vessels.Remove(model);
            
            return true;
        }
    }
}
