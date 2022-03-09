using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        private string number;


        public StationaryPhone(string number)
        {
            Number = number;
        }

        public string Number
        {
            get { return number; }
            set 
            {
              
                number = value; 
            }
        }


        public virtual void Calling()
        {
            foreach (var item in Number)
            {
                if (!char.IsDigit(item))
                {
                    Console.WriteLine("Invalid number!");
                    return;
                }
            }
            Console.WriteLine($"Dialing... {Number}"); ;
        }
    }
}
