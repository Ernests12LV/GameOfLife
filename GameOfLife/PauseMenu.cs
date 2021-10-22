using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class PauseMenu
    {
        public int MenuPause(List<Board> list)
        {
            FileHandler saveAndload = new FileHandler();

            Console.WriteLine();
            Console.WriteLine("Do You want to Switch, Continue Save or Exit? (switch/continue/save/exit)");

            bool passed = false;
            
            int gameToShow = 0;

            while (!passed)
            {

                string userChoice = Console.ReadLine();
                userChoice = userChoice.ToLower();
                userChoice = char.ToUpper(userChoice[0]) + userChoice.Substring(1);

                if (userChoice == GameOptions.Switch.ToString())
                {
                    gameToShow = Switch(list, gameToShow);
                    passed = true;
                }

                else if (userChoice == GameOptions.Continue.ToString())
                {
                    passed = true;
                }
                else if (userChoice == GameOptions.Save.ToString())
                {
                    passed = true;
                    saveAndload.Save(list);
                    Console.Clear();
                    Console.WriteLine("Game Saved SuccessfullY!!!");
                    Console.ReadLine();
                }
                else if (userChoice == GameOptions.Exit.ToString())
                {
                    passed = true;
                    Console.Clear();
                    Console.WriteLine("You are EXITING THE GAME Of LIFE THeeres no going back!!!");
                    Environment.Exit(0);
                }
                else
                {
                    passed = false;
                    Console.WriteLine("Please Enter a Valid Answer!!!");
                }
            }
            return gameToShow;
        }

        public int Switch(List<Board> list, int gameToShow)
        {
            bool invalidBoard = true;
            int gameNum = 0;

            while (invalidBoard)
            {
                Console.WriteLine("Enter Witch Game You Want To Watch " + "1 - " + (list.Count));
                string gameToRun = Console.ReadLine();
                bool boardStatus = int.TryParse(gameToRun, out gameNum);

                if (gameNum > list.Count || gameNum <= 0 || boardStatus == false)
                {
                    Console.WriteLine("Board doesnt exist!!!");
                    Console.WriteLine("Enter Valid Board Number");
                    invalidBoard = true;
                }

                else
                {
                    invalidBoard = false;
                    gameToShow = gameNum - 1;
                }
            }
            return gameToShow;
        }

    }
}
