using System;
using System.Reflection;

namespace MyCoolLibrary
{
    public static class CoolMessagePrinter
    {
        public static void PrintCoolMessage()
        {
            var assemblyName = Assembly.GetExecutingAssembly().FullName;
            Console.WriteLine($"This is a cool message from {assemblyName}.");
        }
    }
}
