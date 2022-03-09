using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers=Console.ReadLine().Split(' ');
            string[] webSites=Console.ReadLine().Split(' ');

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].Length==7)
                {
                    ICallable phone =new StationaryPhone(numbers[i]);
                    phone.Calling();
                }
                else
                {
                    ICallable phone=new Smartphone(numbers[i]);
                    phone.Calling();
                }
            }

            for (int j = 0; j < webSites.Length; j++)
            {
                IBrowsable browser = new Smartphone(webSites[j]);

                browser.Browse();

            }
        }
    }
}
