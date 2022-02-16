using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        Dictionary<string,Pet> data;

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new Dictionary<string,Pet>();
        }

        public int Capacity { get; set; }

        public int Count { get=>data.Count; }

        public void Add(Pet pet)
        {
            if (Count < Capacity) data.Add(pet.Name,pet);
        }

        public bool Remove(string name)
        {
            if (data.ContainsKey(name))
            {
                data.Remove(name);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = data.Where(x => x.Value.Name == name && x.Value.Owner == owner).FirstOrDefault().Value;

            return pet;
        }


        public Pet GetOldestPet()
        {
            Pet oldestPet = data.FirstOrDefault().Value;
            int maxAge = 0;
            foreach (var pet in data)
            {
                if (pet.Value.Age>maxAge)
                {
                    maxAge = pet.Value.Age;
                    oldestPet = pet.Value;
                }
            }

            return oldestPet;
        }


        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in data)
            {
                sb.AppendLine($"Pet {pet.Key} with owner: {pet.Value.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }

}
