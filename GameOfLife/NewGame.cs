using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    public class NewGame
    {
        public void StartNew(bool[,] cellState, int y, int x)
        {
            for (int a = 0; a < y; a++)
            {
                for (int b = 0; b < x; b++)
                {
                    Random random = new Random();
                    int roll = random.Next(0, 2);

                    if (roll == 0)
                    {
                        cellState[a,b] = false;
                    }

                    else
                    {
                        cellState[a,b] = true;
                    }
                }
            }
        }
    }
}
