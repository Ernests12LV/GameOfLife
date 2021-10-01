using System;

namespace GameOfLife
{
    public class DrawBoard
    {
        public void DrawLife(bool[,,]cellState, bool[,,]newCellState, string stateDead, string stateAlive, int y, int x, int i, int gameNum)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Game <{gameNum}>");
            Console.WriteLine("Generation = " + i);
            Console.WriteLine();

            for (int a = 0; a < y; a++)
            {
                for (int b = 0; b < x; b++)
                {
                    cellState[gameNum,a, b] = newCellState[gameNum,a, b];

                    if (newCellState[gameNum,a, b] == false)
                    {
                        Console.Write(stateDead + " ");
                    }
                    else
                    {
                        Console.Write(stateAlive + " ");
                    }
                    if (b == x-1)
                    {
                        Console.WriteLine();
                    }
                }
            }

        }
    }
}
