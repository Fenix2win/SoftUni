using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen:IAddable,IBirthday,IBuyer
    {
        public Citizen(string name, int age, string id,string birthday,int food)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
            Food = food;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }

        public string Birthday { get;}
        public int Food { get ; set ; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
