using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace GameOfLife
{
    public static class Constants
    {
        public static int GetConfigY()
        {
            string confHeight = ConfigurationManager.AppSettings.Get("confY");

            int.TryParse(confHeight, out int y);

            return y;
        }

        public static int GetConfigX()
        {
            string confWidth = ConfigurationManager.AppSettings.Get("confX");

            int.TryParse(confWidth, out int x);

            return x;
        }

        public static string SavedPath = "C:\\Users\\erce\\source\\repos\\GameOfLife\\GameOfLife\\SavedGames\\";

        public static string LayoutPath = "C:\\Users\\erce\\source\\repos\\GameOfLife\\GameOfLife\\Layouts\\";

        public static string StateDead()
        {
            string stateDead;

            Console.Clear();
            Console.WriteLine("Enter any symbol you want the Dead Cells to be displayed as ...");
            stateDead = Console.ReadLine();

            return stateDead;
        }

        public static string StateAlive()
        {
            string stateAlive;

            Console.Clear();
            Console.WriteLine("Enter any symbol you want the Alive Cells to be displayed as ...");
            stateAlive = Console.ReadLine();

            return stateAlive;
        }

    }
}
