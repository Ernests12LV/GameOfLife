using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace GameOfLife
{
    public class DisplayMenu
    {
        public List<Board> Menu(List<Board> list)
        {
            MenuAnimation menuAnimation = new MenuAnimation();
            NewGame game = new NewGame();

            string userInput;
            bool validChoice = false;

            menuAnimation.Animation();

            while (!validChoice)
            {
                userInput = Console.ReadLine();
                userInput = userInput.ToLower();

                if (userInput.Contains("1") || userInput.Contains("new"))
                {
                    game.StartNew(list);
                    validChoice = true;
                }
                else if (userInput.Contains("2") || userInput.Contains("load"))
                {
                    list = Load(list);
                    validChoice = true;
                }
                else if (userInput.Contains("3") || userInput.Contains("exit"))
                {
                    Environment.Exit(0);
                    validChoice = true;
                }
                else
                {
                    validChoice = false;
                    menuAnimation.Animation();
                }
            }
            return list;
        }
        private List<Board> Load(List<Board> list)
        {
            FileHandler fileHandler = new FileHandler();

            string openSpan = "SavedGames\\";
            string jsonString = fileHandler.Load(openSpan, Constants.SavedPath);

            list = JsonConvert.DeserializeObject<List<Board>>(jsonString);

            return list;
        }
    }
}
