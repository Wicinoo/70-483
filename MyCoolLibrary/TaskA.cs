using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyCoolLibrary
{
    class TaskA
    {
        public static class CoolMessagePrinter
        {
            public static void PrintCoolMessage()
            {
                var assemblyName = Assembly.GetCallingAssembly().GetName().Name; // Get assembly full name by reflection.
                Console.WriteLine($"This is a cool message from {assemblyName}.");
            }
        }
    }
}
