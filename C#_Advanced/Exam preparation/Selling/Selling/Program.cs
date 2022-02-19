using System;

namespace Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int colectMoney = 0;
            int row = -1;
            int col = -1;

            //MATRIX INPUT
            for (int r = 0; r < size; r++)
            {
                string input = Console.ReadLine();
                for (int c = 0; c < size; c++)
                {
                    matrix[r, c] = input[c];

                    if (matrix[r, c] == 'S')
                    {
                        row = r;
                        col = c;
                    }
                }
            }

            //ACTION
            string cmd = Console.ReadLine();

            while (colectMoney < 50)
            {
                int targetRow = row;
                int targetCol = col;

                matrix[targetRow, targetCol] = '-';
                switch (cmd)
                {
                    case "up": targetRow -= 1; break;
                    case "down": targetRow += 1; break;
                    case "left": targetCol -= 1; break;
                    case "right": targetCol += 1; break;
                }

                if (targetRow >= 0 && targetCol >= 0 && targetCol < size && targetRow < size)
                {
                    row = targetRow;
                    col = targetCol;
                    //PILAR
                    if (matrix[targetRow, targetCol] == 'O')
                    {
                        matrix[targetRow, targetCol] = '-';

                        for (int r = 0; r < size; r++)
                        {
                            for (int c = 0; c < size; c++)
                            {
                                if (matrix[r, c] == 'O' && targetCol != c && targetRow != r)
                                {
                                    
                                    matrix[targetRow, targetCol] = '-';
                                    targetRow = r;
                                    targetCol = c;
                                    matrix[r, c] = 'S';
                                    row = targetRow;
                                    col = targetCol;
                                }
                            }
                        }
                    }

                    //EMPTY SPACE
                    else if (matrix[targetRow, targetCol] == '-')
                    {
                        matrix[targetRow, targetCol] = 'S';
                    }

                    else
                    {
                        colectMoney += int.Parse(matrix[targetRow, targetCol].ToString());
                        matrix[targetRow, targetCol] = 'S';
                    }


                }
                else
                {
                    matrix[row, col] = '-';
                    break;
                }

                //for (int r = 0; r < size; r++)
                //{
                //    for (int c = 0; c < size; c++)
                //    {
                //        Console.Write(matrix[r, c]);
                //    }
                //    Console.WriteLine();
                //}

                cmd = Console.ReadLine();
            }

            //END
            if (colectMoney >= 50)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }
            Console.WriteLine($"Money: {colectMoney}");

            //PRINT
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    Console.Write(matrix[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
