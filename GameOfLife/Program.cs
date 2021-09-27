using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;


namespace GameOfLife
{

    public class Program
    {
    public static void Main(string[] args)
        {
            
            Game game = new Game();
            Thread[] tr = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                tr[i] = new Thread(new ThreadStart(game.Run));
                tr[i].IsBackground = true;
            }

            foreach (Thread x in tr)
            {
                x.Start();
            }

            game.Run();

        }
    }
}