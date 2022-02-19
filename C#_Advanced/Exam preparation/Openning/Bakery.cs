using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        Dictionary<string,Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new Dictionary<string,Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get=>data.Count;}


        public void Add(Employee employee)
        {
            if (Capacity>Count)
            {
                data.Add(employee.Name, employee);
            }
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

        public Employee GetOldestEmployee()
        {
            int maxAge = 0;
            Employee oldestEmployee = null;

            foreach (Employee employee in data.Values)
            {
                if (employee.Age>maxAge)
                {
                    maxAge = employee.Age;
                    oldestEmployee = employee;
                }
            }
            return oldestEmployee;
        }

        public Employee GetEmployee(string name)
        {
           return data.Where(x=>x.Key==name).FirstOrDefault().Value;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (Employee emp in data.Values)
            {
                sb.AppendLine(emp.ToString());
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}

