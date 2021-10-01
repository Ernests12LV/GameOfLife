using System;

namespace GameOfLife
{
    public class DisplayMenu
    {
        public void Menu(bool[,,] cellState, int y, int x, int z)
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
                userInput = userInput.ToLower();

                if (userInput.Contains("1") || userInput.Contains("new"))
                {
                    game.StartNew(cellState, y, x, z);
                    validChoice = true;
                }
                else if (userInput.Contains("2") || userInput.Contains("load"))
                {
                    load.Load(cellState, y, x, z);
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
