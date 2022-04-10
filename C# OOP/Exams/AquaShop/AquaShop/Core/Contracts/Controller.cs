using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core.Contracts
{
    public class Controller : IController
    {
        private DecorationRepository decorations;

        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }



        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType== "FreshwaterAquarium")
            {
                var aquarium = new FreshwaterAquarium(aquariumName);
                aquariums.Add(aquarium);
            }
            else if (aquariumType== "SaltwaterAquarium")
            {
                var aquarium = new SaltwaterAquarium(aquariumName);
                aquariums.Add(aquarium);
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType== "Ornament")
            {
                var decor = new Ornament();
                decorations.Add(decor);
            }
            
            else if (decorationType== "Plant")
            {
                var decor = new Plant();
                decorations.Add(decor);

            }
           
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");

            }
            
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            IFish fish = null;
            
            if (fishType== "FreshwaterFish")
            {
                fish=new FreshwaterFish(fishName, fishSpecies, price);
            }
           
            else if(fishType== "SaltwaterFish")
            {
                fish=new SaltwaterFish(fishName,fishSpecies, price);
            }
           
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            if (fishType== "FreshwaterFish"&&aquarium.GetType().Name!= "FreshwaterAquarium"
                || fishType == "SaltwaterFish" && aquarium.GetType().Name != "SaltwaterAquarium")
            {
                return "Water not suitable.";
            }
           
            aquarium.AddFish(fish);

            return $"Successfully added {fishType} to {aquariumName}.";

        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var fishPrice = aquarium.Fish.Sum(x => x.Price);
            var decorPrice = aquarium.Decorations.Sum(x => x.Price);

            var totalSum = fishPrice + decorPrice;

            return $"The value of Aquarium {aquariumName} is {totalSum:f2}.";

        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.Feed();

            return $"Fish fed: {aquarium.Fish.Count}";

        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var aquarium=aquariums.FirstOrDefault(x=>x.Name==aquariumName);
           
            var decor=decorations.FindByType(decorationType);
            
            if (decor == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }
           
            aquarium.AddDecoration(decor);
            decorations.Remove(decor);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb=new StringBuilder();
           
            foreach (var aquarium in aquariums)
            {
               sb.AppendLine( aquarium.GetInfo());
            }
          
            return sb.ToString().TrimEnd();
        }
    }
}
