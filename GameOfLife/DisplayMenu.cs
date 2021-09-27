using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    public class DisplayMenu
    {
        public void Menu(bool[,] cellState, int y, int x)
        {
            MenuAnimation menuAnimation = new MenuAnimation();
            NewGame game = new NewGame();
            LoadLayout load = new LoadLayout();

            string userInput;
            bool validChoice = false;

            menuAnimation.Animation();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(">-----User Input----<");
            Console.WriteLine(">-------------------<");

            while (!validChoice)
            {
                userInput = Console.ReadLine();

                if (userInput.Contains("1") || userInput.Contains("new"))
                {
                    game.StartNew(cellState, y, x);
                    validChoice = true;
                }
                else if (userInput.Contains("2") || userInput.Contains("load"))
                {
                    load.Load(cellState);
                    validChoice = true;
                }
                else if (userInput.Contains("3") || userInput.Contains("exit"))
                {
                    Environment.Exit(0);
                    validChoice = true;
                }
                else
                    validChoice = false;
                    menuAnimation.Animation();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(">-----User Input----<");
                    Console.WriteLine("Please Enter a Valid Answer!!!");
            }
        }
    }
}
