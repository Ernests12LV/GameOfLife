using System;
using System.Configuration;
using System.Threading;


namespace GameOfLife
{

    public class Program
    {
    public static void Main()
        {

            CheckCells check = new CheckCells();

            DrawBoard draw = new DrawBoard();

            SaveLayout save = new SaveLayout();

            DisplayMenu displayMenu = new DisplayMenu();

            string confHeight = ConfigurationManager.AppSettings.Get("confY");
            string confWidth = ConfigurationManager.AppSettings.Get("confX");

            int z;
            int i = 0;
            int gameNum = 1;

            int.TryParse(confWidth, out int x);
            int.TryParse(confHeight, out int y);


            bool Life = true;
            bool gameOn = true;
            string stateDead, stateAlive;
            bool checkInput;

            do
            {
                Console.WriteLine("How Many Boards Do You Want?");
                string gameRun = Console.ReadLine();
                checkInput = int.TryParse(gameRun, out int boardNum);
                if (checkInput == false)
                {
                    Console.WriteLine("Please Enter Numbers!!!");
                }
                z = boardNum + 1;
            }
            while (!checkInput);

            bool[,,] cellState = new bool[z, y, x];
            bool[,,] newCellState = new bool[z, y, x];

            displayMenu.Menu(cellState, y, x, z);

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
                        check.Checking(cellState, newCellState, y, x, z);
                        draw.DrawLife(cellState, newCellState, stateDead, stateAlive, y, x, i, gameNum);
                        Thread.Sleep(750);
                    }
                    //
                    Console.WriteLine();
                    Console.WriteLine("Do You want to Switch, Continue Save or Exit? (switch/continue/save/exit)");
                    bool passed = false;
                    bool invalidBoard = true;

                    while (!passed)
                    {

                        string userChoice = Console.ReadLine();
                        userChoice = userChoice.ToLower();
                        userChoice = char.ToUpper(userChoice[0]) + userChoice.Substring(1);

                        if (userChoice == GameOptions.Switch.ToString())
                        {
                            while (invalidBoard)
                            {
                                Console.WriteLine("Enter Witch Game You Want To Watch " + "0 - " + (z - 1));
                                string gameToRun = Console.ReadLine();
                                bool boardStatus = int.TryParse(gameToRun, out gameNum);
                                if (gameNum > (z - 1) || boardStatus == false)
                                {
                                    Console.WriteLine("Board doesnt exist!!!");
                                    Console.WriteLine("Enter Valid Board Number");
                                    invalidBoard = true;
                                }
                                else invalidBoard = false;
                            }
                            passed = true;
                        }

                        else if (userChoice == GameOptions.Continue.ToString())
                        {
                            passed = true;
                            gameOn = true;
                        }
                        else if (userChoice == GameOptions.Save.ToString())
                        {
                            passed = true;
                            save.Save(cellState, y, x, z);
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
                            gameOn = false;
                        }
                        else
                        {
                            passed = false;
                            Console.WriteLine("Please Enter a Valid Answer!!!");
                        }
                    }
                    //
                }
                else
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}