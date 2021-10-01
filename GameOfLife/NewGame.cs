using System;

namespace GameOfLife
{
    public class NewGame
    {
        public void StartNew(bool[,,] cellState, int y, int x, int z)
        {
            for (int c = 0; c < z; c++)
            {
                for (int a = 0; a < y; a++)
                {
                    for (int b = 0; b < x; b++)
                    {
                        Random random = new Random();
                        int roll = random.Next(0, 2);

                        if (roll == 0)
                        {
                            cellState[c, a, b] = false;
                        }

                        else
                        {
                            cellState[c, a, b] = true;
                        }
                    }
                }
            }
        }
    }
}
