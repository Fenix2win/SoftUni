using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb
{
    public class Program
    {
        static void Main(string[] args)
        {

            var effects =new Queue<int> (Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());


            var cassing =new Stack<int> (Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Dictionary<int, string> bombs = new Dictionary<int, string>();
            bombs.Add(40, "Datura Bombs");
            bombs.Add(60, "Cherry Bombs");
            bombs.Add(120, "Smoke Decoy Bombs");

            Dictionary<string, int> pouch = new Dictionary<string, int>();
            pouch.Add("Cherry Bombs", 0);
            pouch.Add("Datura Bombs", 0);
            pouch.Add("Smoke Decoy Bombs", 0);

            int currEffect = effects.Peek();
            int currCassing = cassing.Peek();

            bool isFinishPouch = false;

            while (true)
            {
                if (effects.Count == 0 || cassing.Count == 0) break;

                if(currEffect<=0) currEffect = effects.Peek();
                if(currCassing<=0) currCassing = cassing.Peek();

                int mixture = currEffect + currCassing;

                if (bombs.ContainsKey(mixture))
                {

                    pouch[bombs[mixture]]++;

                    effects.Dequeue();
                    cassing.Pop();
                    currEffect = 0;
                    currCassing = 0;
                }
                else
                {
                    currCassing -= 5;
                }

                if (pouch["Datura Bombs"]>=3&&
                    pouch["Cherry Bombs"] >= 3&&
                    pouch["Smoke Decoy Bombs"] >= 3)
                {
                    isFinishPouch = true;
                    break;
                }
            }
            
            if (isFinishPouch)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (effects.Count == 0) Console.WriteLine("Bomb Effects: empty");
           
            else
            {
                Console.Write("Bomb Effects:+ ");
                Console.WriteLine(string.Join(", ", effects));
            }
            

            if (cassing.Count == 0) Console.WriteLine("Bomb Casings: empty");
           
            else
            {
                Console.Write("Bomb Casings:+ ");
                Console.WriteLine(string.Join(", ", cassing));
            }
            

            foreach (var item in pouch)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}

