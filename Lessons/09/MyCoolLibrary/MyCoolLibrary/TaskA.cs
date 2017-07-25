using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyCoolLibrary
{

    public static class CoolMessagePrinter
    {
        public static void PrintCoolMessage()
        {
            var assemblyName = Assembly.GetExecutingAssembly().FullName; // Get assembly full name by reflection.
            Console.WriteLine($"This is a cool message from {assemblyName}.");
        }
    }
}
