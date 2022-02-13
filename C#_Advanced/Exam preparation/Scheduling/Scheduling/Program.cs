using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {

          Stack<int> tasks =new Stack<int>( Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());


            Queue<int> threads =new Queue<int>( Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int targetTask = int.Parse(Console.ReadLine());

            while (true)
            {
                int currTask=tasks.Peek();
                int currTread=threads.Peek();
                if (currTask == targetTask)
                {
                    Console.WriteLine($"Thread with value {currTread} killed task {currTask}");
                    Console.WriteLine(String.Join(" ",threads));
                    break;
                }

                if (currTread>=currTask)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else if (currTread<currTask)
                {
                    threads.Dequeue();
                }

            }


        }
    }
}
