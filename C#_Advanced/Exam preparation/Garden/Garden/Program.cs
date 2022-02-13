using System;
using System.Linq;

namespace Garden
{
    public class Program
    {
        static void Main(string[] args)
        {

            int[] size = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int row=size[0];
            int col=size[1];

            int[,] garden = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    garden[i, j] = 0;
                }
            }

            string command=Console.ReadLine();

            while (command!= "Bloom Bloom Plow")
            {
                string[] input=command.Split(' ');
                int rowPlant = int.Parse(input[0]);
                int colPlant = int.Parse(input[1]);

                if (IsValidIndex(row,col,rowPlant,colPlant))
                {
                    for (int i = 0; i < row; i++)
                    {
                        garden[i, colPlant] += 1;
                    }

                    for (int j = 0; j < col; j++)
                    {
                        garden[rowPlant, j]+=1;
                    }
                    garden[rowPlant,colPlant]-=1;
                }
                
                 command = Console.ReadLine();

            }

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write($"{garden[i, j]} "); 
                }
                Console.WriteLine();
            }
        }

        private static bool IsValidIndex(int row, int col, int rowPlant, int colPlant)
        {
            return rowPlant>=0&&colPlant>=0&&rowPlant<row&&colPlant<col;
        }
    }
}
