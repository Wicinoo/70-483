using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Anothers.ConsoleOperations
{
    public class ConsoleOperations
    {
        public static void Run()
        {
            var staticText = "Time :";
            Console.Write(staticText);
            do
            {
                while (!Console.KeyAvailable) //auto refresh
                {
                    Console.Write(DateTime.Now.ToString("s"));
                    Console.SetCursorPosition(staticText.Length, Console.CursorTop);
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);  //escape
        }
    }
}
