using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace GameOfLife
{
    public class LoadLayout
    {
        public void Load(bool[,,] cellState, int y, int x, int z)
        {
            const string openSpan = "Layouts\\";
            const string closeSpan = ".json";
            string userChoice;

            string Name_Of_File;
            string layout = @"C:\Users\erce\source\repos\GameOfLife\GameOfLife\Layouts";

            Console.Clear();
            Console.WriteLine("Do you Want to choose or apply Random layouts? (choose/random)");
            userChoice = Console.ReadLine();
            userChoice.ToLower();

            if (userChoice.Contains("choose"))
            {
                Console.Clear();
                Console.WriteLine("Choose File To Load!");

                string[] fileEntries = Directory.GetFiles(layout);

                foreach (string name in fileEntries)
                {
                    int openingPosition = name.IndexOf(openSpan);
                    int closingPosition = name.IndexOf(closeSpan);

                    openingPosition += openSpan.Length;
                    int length = closingPosition - openingPosition;
                    Console.WriteLine(name.Substring(openingPosition, length));
                }

                Name_Of_File = Console.ReadLine();
                Name_Of_File.ToLower();

                string fileName = $@"C:\Users\erce\source\repos\GameOfLife\GameOfLife\Layouts\{Name_Of_File}.json";
                string jsonString = File.ReadAllText(fileName);
                List<JsonModel> l = JsonSerializer.Deserialize<List<JsonModel>>(jsonString);

                for (int c = 0; c < z; c++)
                {
                    for (int i = 0; i < l.Count; i++)
                    {
                        cellState[c, l[i].posY, l[i].posX] = true;
                    }
                }
            }
            else if (userChoice.Contains("random"))
            {
                Console.Clear();

                for (int c = 0; c < z; c++)
                {
                    string[] fileEntries = Directory.GetFiles(layout);

                    var rand = new Random();

                    string fileName = fileEntries[rand.Next(fileEntries.Length)];
                    string jsonString = File.ReadAllText(fileName);
                    List<JsonModel> l = JsonSerializer.Deserialize<List<JsonModel>>(jsonString);
                    for (int i = 0; i < l.Count; i++)
                    {
                        cellState[c, l[i].posY, l[i].posX] = true;
                    }
                }
            }
        }
    }
}
