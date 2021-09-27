using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    class Game
    {
        public void Run()
        {
            CheckCells check = new CheckCells();

            DrawBoard draw = new DrawBoard();

            SaveLayout save = new SaveLayout();

            DisplayMenu displayMenu = new DisplayMenu();

            string confHeight = ConfigurationManager.AppSettings.Get("confY");
            string confWidth = ConfigurationManager.AppSettings.Get("confX");

            int x = 0;
            int y = 0;
            int i = 0;

            int.TryParse(confWidth, out x);
            int.TryParse(confHeight, out y);

            bool[,] cellState = new bool[y, x];
            bool[,] newCellState = new bool[y, x];
            bool Life = true;
            bool gameOn = true;
            bool passed = false;
            string stateDead, stateAlive;

            displayMenu.Menu(cellState, y, x);

            Console.Clear();
            Console.WriteLine("Enter any symbol you want the Alive cells to be displayed as ...");
            stateAlive = Console.ReadLine();

            Console.WriteLine("Enter any symbol you want the Dead cells to be displayed as ...");
            stateDead = Console.ReadLine();

            while (Life)
            {

                if (gameOn)
                {
                    while (!Console.KeyAvailable)
                    {
                        i++;
                        check.Checking(cellState, newCellState, y, x);
                        draw.DrawLife(cellState, newCellState, stateDead, stateAlive, y, x, i);
                        Thread.Sleep(750);
                    }
                    //Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Do You want to Continue or save? (continue/save/exit)");

                    while (!passed)
                    {

                        string userChoice = Console.ReadLine();
                        userChoice.ToLower();
                        userChoice = char.ToUpper(userChoice[0]) + userChoice.Substring(1);

                        if (userChoice == GameOptions.Continue.ToString())
                        {
                            passed = true;
                            gameOn = true;
                        }
                        else if (userChoice == GameOptions.Save.ToString())
                        {
                            passed = true;
                            save.Save(cellState, y, x);
                            Console.Clear();
                            Console.WriteLine("Game Saved SuccessfullY!!!");
                            Console.ReadLine();
                        }
                        else if (userChoice == GameOptions.Exit.ToString())
                        {
                            passed = true;
                            Console.Clear();
                            Console.WriteLine("Are you sure you want to exit? BTw no going back");
                            Console.ReadLine();
                            Environment.Exit(0);
                            gameOn = false;
                        }
                        else
                        {
                            passed = false;
                            Console.WriteLine("Please Enter a Valid Answer!!!");
                        }
                    }

                }
                else
                {
                    Environment.Exit(0);
                }
            }

        }
    }
}
