using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class DrawBoard
    {
        public void DrawLife(Board board, string stateDead, string stateAlive, int gameToShow, int TotalAliveCellCount)
        {
            int gameNum = gameToShow + 1;
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Game <{gameNum}>");
            Console.WriteLine("Generation = " + board.Generation + "                           Alive Cell Count in this Board = " + board.AliveCells + "                     Total Alive Cells = " + TotalAliveCellCount);
            Console.WriteLine();

            if (board.AliveCells == 0)
            {
                Console.WriteLine("THE BOARD IS DEAD");
            }
            else
            {
                for (int a = 0; a < board.Cells.GetLength(0); a++)
                {
                    for (int b = 0; b < board.Cells.GetLength(1); b++)
                    {
                        if (board.Cells[a, b])
                        {
                            Console.Write(stateAlive + " ");
                        }
                        else
                        {
                            Console.Write(stateDead + " ");
                        }
                        if (b == board.Cells.GetLength(1) - 1)
                        {
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
    }
}
