using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife
{
    public class NewGame
    {
        public void StartNew(List<Board> list)
        {
            MenuAnimation menuAnimation = new MenuAnimation();

            string userChoice;

            int boardNum = BoardNumb();
            BoardCreator(boardNum, list);

            menuAnimation.gameStart();

            userChoice = Console.ReadLine();
            userChoice.ToLower();

            if (userChoice.Contains("preset"))
            {
                Preset(boardNum, list);

            }
            else if (userChoice.Contains("random"))
            {
                Random(list);
            }
        }

        private void Preset(int boardNum, List<Board> list)
        {
            FileHandler fileHandler = new FileHandler();

            string openSpan = "Layouts\\";

            string jsonString = fileHandler.Load(openSpan, Constants.LayoutPath);

            List<Board> l = JsonConvert.DeserializeObject<List<Board>>(jsonString);

            for (int i = 0; i < boardNum; i++)
            {
                list[i].Generation = l[0].Generation;
                list[i].AliveCells = l[0].AliveCells;
                list[i].Cells = l[0].Cells;
            }
        }

        private void Random(List<Board> list)
        {
            Console.Clear();

            for (int i = 0; i < list.Count; i++)
            {
                for (int a = 0; a < Constants.GetConfigY(); a++)
                {
                    for (int b = 0; b < Constants.GetConfigX(); b++)
                    {
                        Random random = new Random();
                        int roll = random.Next(0, 2);

                        if (roll == 0)
                        {
                            list[i].Cells[a, b] = false;
                        }

                        else
                        {
                            list[i].Cells[a, b] = true;
                        }
                    }
                }
                //list[i].Cells[3, 5] = true;
                //list[i].Cells[3, 6] = true;
                //list[i].Cells[3, 7] = true;
                //list[i].Cells[3, 11] = true;
                //list[i].Cells[3, 12] = true;
                //list[i].Cells[3, 13] = true;
                //list[i].Cells[5, 3] = true;
                //list[i].Cells[5, 8] = true;
                //list[i].Cells[5, 10] = true;
                //list[i].Cells[5, 15] = true;
                //list[i].Cells[6, 3] = true;
                //list[i].Cells[6, 8] = true;
                //list[i].Cells[6, 10] = true;
                //list[i].Cells[6, 15] = true;
                //list[i].Cells[7, 3] = true;
                //list[i].Cells[7, 8] = true;
                //list[i].Cells[7, 10] = true;
                //list[i].Cells[7, 15] = true;
                //list[i].Cells[8, 5] = true;
                //list[i].Cells[8, 6] = true;
                //list[i].Cells[8, 7] = true;
                //list[i].Cells[8, 11] = true;
                //list[i].Cells[8, 12] = true;
                //list[i].Cells[8, 13] = true;
                //list[i].Cells[10, 5] = true;
                //list[i].Cells[10, 6] = true;
                //list[i].Cells[10, 7] = true;
                //list[i].Cells[10, 11] = true;
                //list[i].Cells[10, 12] = true;
                //list[i].Cells[10, 13] = true;
                //list[i].Cells[11, 3] = true;
                //list[i].Cells[11, 8] = true;
                //list[i].Cells[11, 10] = true;
                //list[i].Cells[11, 15] = true;
                //list[i].Cells[12, 3] = true;
                //list[i].Cells[12, 8] = true;
                //list[i].Cells[12, 10] = true;
                //list[i].Cells[12, 15] = true;
                //list[i].Cells[13, 3] = true;
                //list[i].Cells[13, 8] = true;
                //list[i].Cells[13, 10] = true;
                //list[i].Cells[13, 15] = true;
                //list[i].Cells[15, 5] = true;
                //list[i].Cells[15, 6] = true;
                //list[i].Cells[15, 7] = true;
                //list[i].Cells[15, 11] = true;
                //list[i].Cells[15, 12] = true;
                //list[i].Cells[15, 13] = true;
            }
        }

        private int BoardNumb()
        {
            bool checkInput;
            int boardNum;

            do
            {
                Console.WriteLine("How Many Boards Do You Want?");
                string gameRun = Console.ReadLine();
                checkInput = int.TryParse(gameRun, out boardNum);
                if (checkInput == false)
                {
                    Console.WriteLine("Please Enter Numbers!!!");
                }
            }
            while (!checkInput);
            return boardNum;
        }

        private void BoardCreator(int boardNum, List<Board> list)
        {

            for (int n = 0; n < boardNum; n++)
            {

                Board board = new Board
                {
                    AliveCells = 1,
                    Cells = new bool[Constants.GetConfigY(), Constants.GetConfigX()]
                };
                list.Add(board);

            }
        }
    }
}
