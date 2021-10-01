namespace GameOfLife
{
    public class CheckCells
    {
        public void Checking(bool[,,] cellState, bool[,,] newCellState, int y, int x, int z)
        {
            int x1, y1;
            int aliveCount;

            for (int c = 1; c < z; c++)
            {
                for (y1 = 1; y1 < y - 1; y1++)
                {
                    for (x1 = 1; x1 < x - 1; x1++)
                    {
                        // Counts every cells live nb cells
                        aliveCount = 0;
                        if (cellState[c, y1 - 1, x1 - 1] == true) aliveCount++;
                        if (cellState[c, y1 - 1, x1] == true) aliveCount++;
                        if (cellState[c, y1 - 1, x1 + 1] == true) aliveCount++;
                        if (cellState[c, y1, x1 - 1] == true) aliveCount++;
                        if (cellState[c, y1, x1 + 1] == true) aliveCount++;
                        if (cellState[c, y1 + 1, x1 - 1] == true) aliveCount++;
                        if (cellState[c, y1 + 1, x1] == true) aliveCount++;
                        if (cellState[c, y1 + 1, x1 + 1] == true) aliveCount++;

                        if (cellState[c, y1, x1] == true) //if cell alive
                        {
                            if (aliveCount < 2 || aliveCount > 3) // if alive nb count less or more than 3
                            {
                                //Cell dies
                                newCellState[c, y1, x1] = false;
                            }
                            else if (aliveCount >= 2 && aliveCount <= 3) // if alive nb count 2 or 3 
                            {
                                //Cell lives
                                newCellState[c, y1, x1] = true;
                            }
                        }
                        else if (aliveCount == 3) // if cell dead & if cell alive nb count is 3
                        {
                            //Cell lives
                            newCellState[c, y1, x1] = true;
                        }
                    }
                }
            }
        }    
    }
}
