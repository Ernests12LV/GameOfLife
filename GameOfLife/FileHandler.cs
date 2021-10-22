using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GameOfLife
{
    class FileHandler
    {
        public string Load(string openSpan, string path)
        {
            string closeSpan = ".json";

            string fileName;

            Console.Clear();
            Console.WriteLine("Choose File To Load!");
            Console.WriteLine("");

            string[] fileEntries = Directory.GetFiles(path);

            foreach (string name in fileEntries)
            {
                int openingPosition = name.IndexOf(openSpan);
                int closingPosition = name.IndexOf(closeSpan);

                openingPosition += openSpan.Length;
                int length = closingPosition - openingPosition;
                string layoutName = name.Substring(openingPosition, length);

                Console.WriteLine(layoutName);
            }

            fileName = Console.ReadLine();
            fileName.ToLower();

            string filePath = $@"{path}{fileName}.json";
            string jsonString = File.ReadAllText(filePath);

            return jsonString;
        }

        public void Save(List<Board> list)
        {
            MenuAnimation menuAnimation = new MenuAnimation();

            string fileName;
            bool gameSaved = false;

            Console.Clear();
            Console.WriteLine("Enter File Name!!!");
            fileName = Console.ReadLine();
            fileName.ToLower();

            string Name_Of_File = $@"{Constants.SavedPath}{fileName}.json";

            do
            {
                if (File.Exists(Name_Of_File))
                {
                    menuAnimation.fileAlreadyExist();
                    fileName = Console.ReadLine();
                    fileName.ToLower();
                    Name_Of_File = $@"{Constants.SavedPath}{fileName}.json";
                }
                else
                    gameSaved = true;
            }
            while (!gameSaved);

            string json = JsonConvert.SerializeObject(list);

            File.WriteAllText(Name_Of_File, json);
        }

    }
}