using System;

namespace GameOfLife
{
    public class DrawBoard
    {
        public void DrawLife(bool[,]cellState, bool[,]newCellState, string stateDead, string stateAlive, int y, int x, int i)
        {

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Generation = " + i);
            Console.WriteLine();

            for (int a = 0; a < y; a++)
            {
                for (int b = 0; b < x; b++)
                {
                    cellState[a, b] = newCellState[a, b];

                    if (newCellState[a, b] == false)
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
