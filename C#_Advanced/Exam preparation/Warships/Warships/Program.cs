using System;

namespace Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int size = int.Parse(Console.ReadLine());
            string[] commandInput = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = new char[size, size];
            int firstPlayerShips = 0;
            int secondPlayerShips = 0;
            int destroyedShips = 0;
            int targetRow = 0;
            int targetCol = 0;


            //INPUT LINES

            for (int r = 0; r < size; r++)
            {
                string input = Console.ReadLine();
                char[] charArray = input.Replace(" ", "").ToCharArray();

                for (int c = 0; c < size; c++)
                {
                    matrix[r, c] = charArray[c];

                    if (matrix[r, c] == '<') firstPlayerShips++;
                    if (matrix[r, c] == '>') secondPlayerShips++;
                }
            }

            //ATTACS
            for (int i = 0; i < commandInput.Length; i++)
            {

                string[] cmd = commandInput[i]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(cmd[0]);
                int col = int.Parse(cmd[1]);

                if (!IsValid(size, row, col)) continue;

                if (matrix[row,col]=='>')
                {
                    matrix[row, col] = 'X';
                    secondPlayerShips--;
                    destroyedShips++;
                }
                
                else if (matrix[row, col] == '<')
                {
                    matrix[row, col] = 'X';
                    firstPlayerShips--;
                    destroyedShips++;
                }

                else if (matrix[row, col] == '#')//
                {
                    matrix[row, col] = 'X';

                    targetRow = row - 1;
                    targetCol = col - 1;
                    if (IsValid(size,targetRow,targetCol))
                    {
                        if (matrix[targetRow,targetCol]=='<')
                        {
                            firstPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }
                        
                        if (matrix[targetRow, targetCol] == '>')
                        {
                            secondPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }
                    }

                   targetRow = row - 1;
                   targetCol = col ;
                    if (IsValid(size, targetRow, targetCol))
                    {
                        if (matrix[targetRow, targetCol] == '<')
                        {
                            firstPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }

                        if (matrix[targetRow, targetCol] == '>')
                        {
                            secondPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }
                    }


                    targetRow = row - 1;
                    targetCol = col+1;
                    if (IsValid(size, targetRow, targetCol)) 
                    {
                        if (matrix[targetRow, targetCol] == '<')
                        {
                            firstPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }

                        if (matrix[targetRow, targetCol] == '>')
                        {
                            secondPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }
                    }

                    targetRow = row ;
                    targetCol = col-1; 
                    if (IsValid(size, targetRow, targetCol))
                    {
                        if (matrix[targetRow, targetCol] == '<')
                        {
                            firstPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }

                        if (matrix[targetRow, targetCol] == '>')
                        {
                            secondPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }
                    }

                    targetRow = row ;
                    targetCol = col+1;
                    if (IsValid(size, targetRow, targetCol))
                    {
                        if (matrix[targetRow, targetCol] == '<')
                        {
                            firstPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }

                        if (matrix[targetRow, targetCol] == '>')
                        {
                            secondPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }
                    }

                    targetRow = row + 1;
                    targetCol = col-1;
                    if (IsValid(size, targetRow, targetCol))
                    {
                        if (matrix[targetRow, targetCol] == '<')
                        {
                            firstPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }

                        if (matrix[targetRow, targetCol] == '>')
                        {
                            secondPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }
                    }

                    targetRow = row + 1;
                    targetCol = col ;
                    if (IsValid(size, targetRow, targetCol))
                    {
                        if (matrix[targetRow, targetCol] == '<')
                        {
                            firstPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }

                        if (matrix[targetRow, targetCol] == '>')
                        {
                            secondPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }
                    }

                    targetRow = row + 1;
                    targetCol = col + 1;
                    if (IsValid(size, targetRow, targetCol))
                    {
                        if (matrix[targetRow, targetCol] == '<')
                        {
                            firstPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }

                        if (matrix[targetRow, targetCol] == '>')
                        {
                            secondPlayerShips--;
                            destroyedShips++;
                            matrix[targetRow, targetCol] = 'X';
                        }
                    }
                }


                if (secondPlayerShips==0)
                {
                    Console.WriteLine($"Player One has won the game! {destroyedShips} ships have been sunk in the battle.");
                    return;
                }

                else if (firstPlayerShips==0)
                {
                    Console.WriteLine($"Player Two has won the game! {destroyedShips} ships have been sunk in the battle.");
                    return;
                }
            }

            Console.WriteLine($"It's a draw! Player One has {firstPlayerShips} ships left. Player Two has {secondPlayerShips} ships left.");





            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    Console.Write($"{matrix[r,c]} ");
                }
                Console.WriteLine();
            }

            
           
        }

        private static bool IsValid(int size, int row, int col)
        {
            return row >= 0 && col >= 0 && row < size && col < size;
        }
    }
}
