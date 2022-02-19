using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var lilies =new Stack<int> (Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var roses = new Queue<int>(Console.ReadLine()
              .Split(", ", StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray());

            int wreaths = 0;
            List<int> flowersOver = new List<int>();
            int decrease=0;

            while (lilies.Count>0&&roses.Count>0)
            {
                int currLilies=lilies.Peek()-decrease;
                int currRoses=roses.Peek();

                int sum=currLilies+currRoses;
                if (sum == 15)
                {
                    wreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                decrease = 0;
                }

                else if (sum > 15)
                {
                    decrease += 2;
                }

                else if (sum<15)
                {
                    flowersOver.Add(sum);
                    lilies.Pop();
                    roses.Dequeue();
                    decrease = 0;

                }

            }

            int wreathsFromOverFlowers = flowersOver.Sum()/15;

            wreaths += wreathsFromOverFlowers;

            if (wreaths>=5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wreaths} wreaths more!");
            }
        }
    }
}
