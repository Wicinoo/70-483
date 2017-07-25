using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCoolLibrary
{
    public static class CoolMessagePrinter
    {
        public static void PrintCoolMessage()
        {
            var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().FullName;
            Console.WriteLine($"This is a cool message from {assemblyName}.");
        }
    }
}
