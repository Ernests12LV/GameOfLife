using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace GameOfLife
{
    public class SaveLayout
    {
        public void Save(bool[,] cellState, int y, int x)
        {
            int Ypos;
            int Xpos;
            string fileName;
            bool gameSaved = false;

            Console.Clear();
            Console.WriteLine("Enter File Name!!!");
            fileName = Console.ReadLine();

            string Name_Of_File = $@"C:\Users\erce\source\repos\GameOfLife\GameOfLife\Layouts\{fileName}.json";

            do
            {
                if (File.Exists(Name_Of_File))
                {
                    Console.Clear();
                    Console.WriteLine("!!!Can not SAVE the game!!!");
                    Console.WriteLine("!!!File with that name already exists!!!");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Enter File Name!!!");
                    fileName = Console.ReadLine();
                    Name_Of_File = $@"C:\Users\erce\source\repos\GameOfLife\GameOfLife\Layouts\{fileName}.json";
                }
                else
                    gameSaved = true;
            }
            while (!gameSaved);

            List <JsonModel> _JsonModel = new List<JsonModel>();

            for (int a = 0; a < y; a++)
            {
                for (int b = 0; b < x; b++)
                {
                    if (cellState[a, b] == true)
                    {
                        Ypos = a;
                        Xpos = b;
                        _JsonModel.Add(new JsonModel()
                        {
                            posY = Ypos,
                            posX = Xpos
                        });
                        string json = JsonSerializer.Serialize(_JsonModel);
                        File.WriteAllText(Name_Of_File, json);
                    }
                }
            }
        }
    }
}
