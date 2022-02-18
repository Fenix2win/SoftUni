using System;

namespace Snake
{
    public class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            int lair_1_Row = -1;
            int lair_1_Col = -1;
            int lair_2_Row = -1;
            int lair_2_Col = -1;

            int snakeRow = -1;
            int snakeCol = -1;
            int foodCount = 0;

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string input = Console.ReadLine();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = input[c];

                    if (matrix[r, c] == 'B')
                    {
                        if (lair_1_Row == -1)
                        {
                            lair_1_Row = r;
                            lair_1_Col = c;
                        }
                        else
                        {
                            lair_2_Row = r;
                            lair_2_Col = c;
                        }

                    }

                    else if (matrix[r, c] == 'S')
                    {
                        snakeRow = r;
                        snakeCol = c;
                    }
                }
            }

            int targetRow = snakeRow;
            int targetCol = snakeCol;

            while (true)
            {

                string cmd = Console.ReadLine();

                if (cmd == "up") targetRow = snakeRow - 1;
                if (cmd == "down") targetRow = snakeRow + 1;
                if (cmd == "left") targetCol = snakeCol - 1;
                if (cmd == "right") targetCol = snakeCol + 1;


                if (IsNotValid(size, targetRow, targetCol))
                {
                    if (matrix[targetRow, targetCol] == 'B')
                    {
                        if (targetRow == lair_1_Row)
                        {
                            matrix[snakeRow, snakeCol] = '.';
                            matrix[lair_1_Row, lair_1_Col] = '.';
                            matrix[lair_2_Row, lair_2_Col] = 'S';
                            snakeRow = lair_2_Row;
                            snakeCol = lair_2_Col;
                            targetRow = snakeRow;
                            targetCol = snakeCol;
                        }

                        else
                        {
                            matrix[snakeRow, snakeCol] = '.';

                            matrix[lair_1_Row, lair_1_Col] = 'S';
                            matrix[lair_2_Row, lair_2_Col] = '1';
                            snakeRow = lair_1_Row;
                            snakeCol = lair_1_Col;
                            targetRow = snakeRow;
                            targetCol = snakeCol;
                        }

                    }

                    else if (matrix[targetRow, targetCol] == '*')
                    {
                        matrix[targetRow, targetCol] = 'S';
                        matrix[snakeRow, snakeCol] = '.';
                        snakeRow = targetRow;
                        snakeCol = targetCol;
                        foodCount++;
                    }
                    else
                    {
                        matrix[targetRow, targetCol] = 'S';
                        matrix[snakeRow, snakeCol] = '.';
                        snakeRow = targetRow;
                        snakeCol = targetCol;
                    }
                }

                else
                {
                    Console.WriteLine("Game over!");
                    matrix[snakeRow, snakeCol] = '.';
                    break;
                }

                if (foodCount >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }





                for (int r = 0; r < size; r++)
                {
                    for (int c = 0; c < size; c++)
                    {
                        global::System.Console.Write(matrix[r, c]);
                    }
                    global::System.Console.WriteLine();
                }




            }

            Console.WriteLine($"Food eaten: {foodCount}");

            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    global::System.Console.Write(matrix[r, c]);
                }
                global::System.Console.WriteLine();
            }


        }

        private static bool IsNotValid(int size, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetCol >= 0 && targetRow < size && targetCol < size;

        }
    }
}
