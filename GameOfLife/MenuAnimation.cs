using System;
using System.Drawing;
using System.Threading;

namespace GameOfLife
{
    public class MenuAnimation
    {
        public void Animation()
        {
            var margin = "".PadLeft(110);
            var margin2 = "".PadLeft(95);

                Console.Clear();

                for (int n = 0; n < 15; n++)
                {
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(margin2 + "  #######                               ##", Color.DeepSkyBlue);
                Console.WriteLine(margin2 + " #########                              ##", Color.DeepSkyBlue);
                Console.WriteLine(margin2 + "##       ##                             ##", Color.DeepSkyBlue);
                Console.WriteLine(margin2 + "##       ##                             ##", Color.DeepSkyBlue);
                Console.WriteLine(margin2 + "##                                      ##", Color.DeepSkyBlue);
                Console.WriteLine(margin2 + "##    #####           #######           ##", Color.DeepSkyBlue);
                Console.WriteLine(margin2 + "##    #####          ##     ##          ##", Color.DeepSkyBlue);
                Console.WriteLine(margin2 + "##       ##         ##       ##         ##", Color.DeepSkyBlue);
                Console.WriteLine(margin2 + "##       ##         ##       ##         ##", Color.DeepSkyBlue);
                Console.WriteLine(margin2 + " #########           ##     ##          ###########", Color.DeepSkyBlue);
                Console.WriteLine(margin2 + "  #######             #######           ###########", Color.DeepSkyBlue);

                for (int n = 0; n < 10; n++)
                {
                    Console.WriteLine();
                }

                for (int n = 0; n < 10; n++)
                {
                    Console.WriteLine();
                }

                Console.WriteLine(margin + "══════════════════");
                Console.WriteLine(margin + "1) Start new Game");
                Console.WriteLine(margin + "2)  Load Game");
                Console.WriteLine(margin + "3)    Exit");
                Console.WriteLine(margin + "═════════════════");
        }
    }
}
