using System;

namespace GameOfLife
{
    public class InputValidation
    {
        public string answer;
        public void InputCheck()
        {
            
            int cords;
            bool success;

            do
            {
                answer = Console.ReadLine();
                success = int.TryParse(answer, out cords);

                if (success)
                {
                    Console.WriteLine();
                }
                /*
                if (string.IsNullOrEmpty(a.answer))
                {
                    Console.WriteLine("You can't leave it empty !!!");
                }
                */
                else
                {
                    Console.WriteLine("You need to enter NUMBERS !!!");
                    Console.WriteLine("------------!!!--------------");
                    Console.WriteLine("!!! Please ENTER NUMBERS !!!");
                }
            }
            while (!success);
            
        }
    }
}