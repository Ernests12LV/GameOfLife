using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class BoardCheck
    {
        public void Checking(Board board)
        {
            int x, y;
            int aliveNbCount;
            int aliveCellCount = 0;
            bool[,] newCells = new bool[board.Cells.GetLength(0), board.Cells.GetLength(1)];
            if (board.AliveCells > 0)
            {
                board.Generation++;
                for (y = 1; y < board.Cells.GetLength(0) - 1; y++)
                {
                    for (x = 1; x < board.Cells.GetLength(1) - 1; x++)
                    {
                        if (board.Cells[y, x] == true) aliveCellCount++;

                        // Counts every Cells live nb Cells
                        aliveNbCount = 0;
                        if (board.Cells[y - 1, x - 1] == true) aliveNbCount++;
                        if (board.Cells[y - 1, x] == true) aliveNbCount++;
                        if (board.Cells[y - 1, x + 1] == true) aliveNbCount++;
                        if (board.Cells[y, x - 1] == true) aliveNbCount++;
                        if (board.Cells[y, x + 1] == true) aliveNbCount++;
                        if (board.Cells[y + 1, x - 1] == true) aliveNbCount++;
                        if (board.Cells[y + 1, x] == true) aliveNbCount++;
                        if (board.Cells[y + 1, x + 1] == true) aliveNbCount++;

                        //if cell alive
                        if (board.Cells[y, x] == true) 
                        {
                            // if alive nb count less or more than 3
                            if (aliveNbCount < 2 || aliveNbCount > 3) 
                            {
                                //Cell dies
                                newCells[y, x] = false;
                            }
                            // if alive nb count 2 or 3 
                            else if (aliveNbCount >= 2 && aliveNbCount <= 3) 
                            {
                                //Cell lives
                                newCells[y, x] = true;
                            }
                        }
                        // if cell dead & if cell alive nb count is 3
                        else if (aliveNbCount == 3) 
                        {
                            //Cell lives
                            newCells[y, x] = true;
                        }
                    }
                }
            }
            board.AliveCells = aliveCellCount;
            board.Cells = newCells;
        }
    }
}
