using System;
using System.Collections.Generic;
using System.Threading;


namespace GameOfLife
{

    public class Program
    {
        public static void Main()
        {

            BoardCheck boardCheck = new BoardCheck();
            DrawBoard drawBoard = new DrawBoard();
            DisplayMenu displayMenu = new DisplayMenu();
            PauseMenu pauseMenu = new PauseMenu();

            List<Board> list = new List<Board>();

            int gameToShow = 0;
            int TotalAliveCellCount;

            string stateAlive, stateDead;

            bool Life = true;

            list = displayMenu.Menu(list);

            stateAlive = Constants.StateAlive();
            stateDead = Constants.StateDead();

            while (Life)
            {
                while (!Console.KeyAvailable)
                {
                    TotalAliveCellCount = 0;

                    for (int num = 0; num < list.Count; num++)
                    {
                        boardCheck.Checking(list[num]);
                        TotalAliveCellCount += list[num].AliveCells;
                    }

                    drawBoard.DrawLife(list[gameToShow], stateDead, stateAlive, gameToShow, TotalAliveCellCount);
                    Thread.Sleep(750);
                }

                gameToShow = pauseMenu.MenuPause(list);
            }
        }
    }
}