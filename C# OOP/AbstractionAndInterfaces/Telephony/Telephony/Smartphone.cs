using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : StationaryPhone, ICallable, IBrowsable
    {
       

        public Smartphone(string input): base(input)
        {
           Number = input;
            Web = input;
        }

        public string Name { get; set; }
        public string Web { get; set; }





        public void Browse()
        {
        foreach (var item in Web)
        {
            if (char.IsDigit(item))
            {
                Console.WriteLine("Invalid URL!");
                return;
            }
        }
        Console.WriteLine($"Browsing: {Web}!");
        }

        public override void Calling()
        
        {
            foreach (var item in Number)
            {
                if (!char.IsDigit(item))
                {
                    Console.WriteLine("Invalid number!");
                    return;
                }
            }
            Console.WriteLine($"Calling... {Number}");
        }
    }
}
